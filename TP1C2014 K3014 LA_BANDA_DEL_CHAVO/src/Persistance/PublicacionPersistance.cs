﻿using System;
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
        public static Publicacion GetById(int id)
        {
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
                catch (Exception e)
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

        public static List<Publicacion> GetAllByUserId(int userId)
        {
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
    }
}
