using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Persistance
{
    public static class PublicacionPersistance
    {
        public static Publicacion GetPublicationById(int id)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", id)
                };

            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetPublicacionById, param);

            var publications = sp.ExecuteReader<Publicacion>();

            if (publications == null || publications.Count == 0)
                return null;

            publications[0].GetObjectsById();
            return publications[0];
        }

        public static int InsertPublication(Publicacion publication)
        {
            //Tiene que insertar en la tabla TL_Publicacion, TL_Rubro_Publicacion
            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    publication = InsertPublication(publication, transaction);
                    var categoriesAdded = RubroPersistance.InsertByPublication(publication, transaction);

                    if (categoriesAdded > 0)
                    {
                        transaction.Commit();
                        return 1;
                    }

                    transaction.Rollback();
                    return 0;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Se produjo un error durante la insercion del rol");
                }
            }
        }

        public static Publicacion InsertPublication(Publicacion publication, SqlTransaction transaction)
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
                        ? new StoreProcedure(DataBaseConst.Publicacion.SPInsertPublicacion, param, transaction)
                        : new StoreProcedure(DataBaseConst.Publicacion.SPInsertPublicacion, param);


            var das = sp.ExecuteScalar(transaction);
            publication.ID = Convert.ToInt32(das);

            return publication;
        }
    }
}
