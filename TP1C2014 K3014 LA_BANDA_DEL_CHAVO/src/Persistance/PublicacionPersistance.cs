using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Configuration;

namespace Persistance
{
    public static class PublicacionPersistance
    {
        public static Publicacion GetById(int id)
        {
            //Obtengo la publicacion cuyo ID coincida con el valor recibido por parametro
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", id)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetById, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            publications[0].GetObjectsById();
            return publications[0];
        }

        public static int Insert(Publicacion publication)
        {
            //Tiene que insertar en la tabla TL_Publicacion, TL_Rubro_Publicacion
            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    publication = Insert(publication, transaction);
                    var categoriesAdded = RubroPersistance.InsertByPublication(publication, transaction);

                    if (categoriesAdded > 0)
                    {
                        transaction.Commit();
                        return 1;
                    }

                    transaction.Rollback();
                    return 0;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Se produjo un error durante la insercion de la publicacion");
                }
            }
        }

        public static Publicacion Insert(Publicacion publication, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Tipo_Publicacion", publication.TipoPublicacion.ID),
                    new SPParameter("Descripcion", publication.Descripcion), 
                    new SPParameter("ID_Usuario", publication.UsuarioCreador.ID),
                    new SPParameter("Stock", publication.Stock), 
                    new SPParameter("Fecha_Inicio", publication.FechaInicio), 
                    new SPParameter("Fecha_Vencimiento", publication.FechaVencimiento),
                    new SPParameter("Precio", publication.Precio),
                    new SPParameter("ID_Visibilidad", publication.Visibilidad.ID), 
                    new SPParameter("ID_Estado_Publicacion", publication.EstadoPublicacion.ID),
                    new SPParameter("Permitir_Preguntas", publication.RecibirPreguntas)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Publicacion.SPInsert, param, transaction)
                        : new StoreProcedure(DataBaseConst.Publicacion.SPInsert, param);

            publication.ID = Convert.ToInt32(sp.ExecuteScalar(transaction));

            return publication;
        }

        public static List<Publicacion> GetAllActive()
        {
            //Obtengo la publicacion que se encuentren activas
            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_hoy", Configuration.ConfigurationVariables.FechaSistema)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllActive, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            foreach (var pub in publications)
            {
                pub.GetObjectsById();
            }

            return publications;
        }

        public static List<Publicacion> GetAllActiveByParameters(String description, List<Rubro> lstRubros)
        {
            //Obtengo la publicacion que se encuentren activas y cumplan ciertos criterios (busqueda exacta)
            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_hoy", Configuration.ConfigurationVariables.FechaSistema),
                    new SPParameter("Descripcion", description)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllActiveByParameters, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null)
                return null;

            var result = new List<Publicacion>();
            foreach (var pub in publications)
            {
                pub.GetObjectsById();
                if (pub.Rubros.Count == lstRubros.Count && pub.Rubros.Select(i => i.ID).Intersect(lstRubros.Select(j => j.ID)).Count() == pub.Rubros.Count)
                    result.Add(pub);
            }

            return result;
        }

        public static List<Publicacion> GetAllActiveByParametersLike(String description, List<Rubro> lstRubros)
        {
            //Obtengo la publicacion que se encuentren activas y cumplan ciertos criterios (busqueda inexacta)
            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_hoy", Configuration.ConfigurationVariables.FechaSistema),
                    new SPParameter("Descripcion", description)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllActiveByParametersLike, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            var result = new List<Publicacion>();
            foreach (var pub in publications)
            {
                pub.GetObjectsById();
                if (lstRubros.Count == 0 || pub.Rubros.Select(i => i.ID).Intersect(lstRubros.Select(j => j.ID)).Count() > 0)
                    result.Add(pub);
            }

            return result;
        }

        public static List<Publicacion> GetAllByUserId(int userId)
        {
            //Obtengo las publicaciones de determinado usuario
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", userId)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllByUserId, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            return publications;
        }

        public static int Update(Publicacion publication)
        {
            /* Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar un rol insertado
            sin las funcionalidades asociadas debido a un error */
            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    Update(publication, transaction);

                    if (RubroPersistance.DeleteByPublication(publication, transaction) > 0)
                    {
                        if (RubroPersistance.InsertByPublication(publication, transaction) > 0)
                        {
                            //La unica forma que se realice la transaction: borro todas los rubros viejos e inserto los nuevos
                            transaction.Commit();
                            return 1;
                        }
                        else
                        {
                            //Tuvo que haber insertado por lo menos uno, sino es un error
                            transaction.Rollback();
                            return 0;
                        }
                    }
                    else
                    {
                        //Tuvo que haber insertado por lo menos uno, sino es un error
                        transaction.Rollback();
                        return 0;
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Se produjo un error durante la modificacion de la publicacion");
                }
            }
        }

        public static int Update(Publicacion publication, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", publication.ID),
                    new SPParameter("ID_Tipo_Publicacion", publication.TipoPublicacion.ID),
                    new SPParameter("Descripcion", publication.Descripcion), 
                    new SPParameter("Stock", publication.Stock), 
                    new SPParameter("Precio", publication.Precio),
                    new SPParameter("ID_Visibilidad", publication.Visibilidad.ID), 
                    new SPParameter("ID_Estado_Publicacion", publication.EstadoPublicacion.ID),
                    new SPParameter("Permitir_Preguntas", publication.RecibirPreguntas)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Publicacion.SPUpdate, param, transaction)
                        : new StoreProcedure(DataBaseConst.Publicacion.SPUpdate, param);

            return sp.ExecuteNonQuery(transaction);
        }

        public static List<Publicacion> GetPublicacionesARendirByUser(int userId)
        {
            //Obtengo la lista de publicaciones de determinado usuario que no se hayan rendido
            var param = new List<SPParameter>
                {
                    new SPParameter("Id_User", userId),
                    new SPParameter("Fecha_Actual", Configuration.ConfigurationVariables.FechaSistema)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetPublicacionesARendirByUser, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            return publications;
        }

        public static List<Publicacion> GetPublicacionesMasAntiguasARendirByUser(int userId, int cantidad)
        {
            //Obtengo la lista de publicaciones más antiguas de determinado usuario que no se hayan rendido
            var param = new List<SPParameter>
                {
                    new SPParameter("Id_User", userId),
                    new SPParameter("Cantidad", cantidad),
                    new SPParameter("Fecha_Actual", Configuration.ConfigurationVariables.FechaSistema)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetPublicacionesMasAntiguasARendirByUser, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            return publications;
        }

        public static List<Publicacion> GetAllByParameters(Filters.PublicacionFilters filters)
        {
            //Obtengo la lista de publicaciones que cumplan determinadas condiciones (busqueda exacta)
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", filters.IdUsuario),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Stock", filters.Stock ?? (object)DBNull.Value),
                    new SPParameter("Precio", filters.Precio ?? (object)DBNull.Value),
                    new SPParameter("ID_Estado_Publicacion", filters.IdEstadoPublicacion ?? (object)DBNull.Value),
                    new SPParameter("ID_Visibilidad", filters.IdVisibilidad ?? (object)DBNull.Value),
                    new SPParameter("ID_Tipo_Publicacion", filters.IdTipoPublicacion ?? (object)DBNull.Value),
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllPublicacionByParameters, param);

            return sp.ExecuteReader<Publicacion>();
        }

        public static List<Publicacion> GetAllByParametersLike(Filters.PublicacionFilters filters)
        {
            //Obtengo la lista de publicaciones que cumplan determinadas condiciones (busqueda inexacta)
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", filters.IdUsuario),
                    new SPParameter("Descripcion", filters.Descripcion)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllPublicacionByParametersLike, param);

            return sp.ExecuteReader<Publicacion>();
        }

        public static List<PreguntaRespuesta> GetQuestionsAndAnswersById(int IdPublicacion)
        {
            //Obtengo la lista de preguntas y respuestas de una determinada publicacion
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", IdPublicacion)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetQuestionsAndAnswersById, param);

            return sp.ExecuteReader<PreguntaRespuesta>();
        }

        public static List<Publicacion> GetAllByVisibility(int visibilityId)
        {
            //Obtengo la lista de publicaciones cuya visibilidad coincida con el valor recibido por parametro
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Visibilidad", visibilityId)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllByVisibilityId, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return new List<Publicacion>();

            return publications;
        }

        public static int GetAllActiveAndFreeByUser(int userId)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", userId)
                };

            var quantity = 0;
            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetAllActiveAndFreeByUserId, param);

            var reader = sp.ExecuteReader(null);
            while (reader.Read())
                quantity = Convert.ToInt32(reader[0]);

            if (!reader.IsClosed)
                reader.Close();

            return quantity;
        }

        public static List<Publicacion> GetFinishedAuctions()
        {
            //Obtengo la lista de publicaciones que ya hayan vencido para pasarlas a compras
            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_Hoy", ConfigurationVariables.FechaSistema)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetFinishedAuctions, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return new List<Publicacion>();

            foreach (var pub in publications)
            {
                pub.GetObjectsById();
            }

            return publications;
        }
    }
}
