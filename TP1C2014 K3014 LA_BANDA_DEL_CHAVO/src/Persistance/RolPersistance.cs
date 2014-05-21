﻿using System;
using System.Collections.Generic;
using Persistance.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Persistance
{
    public static class RolPersistance
    {
        public static List<Rol> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetAllRol);
            return sp.ExecuteReader<Rol>();
        }

        public static List<Rol> GetByUser(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("ID_User", user.ID) };
            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetAllRolByUser, param);

            return sp.ExecuteReader<Rol>();
        }

        public static Rol GetByName(String description)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", description)
                };

            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetRolByName, param);

            var roles = sp.ExecuteReader<Rol>();

            if (roles == null || roles.Count == 0)
                return null;

            return roles[0];
        }

        public static List<Rol> GetByNameLike(String description)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", description)
                };

            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetAllRolByNameLike, param);

            return sp.ExecuteReader<Rol>();
        }

        public static Rol InsertRole(Rol role, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", role.Descripcion), 
                    new SPParameter("Activo", role.Activo)
                };

            var sp = (transaction != null) 
                        ? new StoreProcedure(DataBaseConst.Rol.SPInsertRol, param, transaction)
                        : new StoreProcedure(DataBaseConst.Rol.SPInsertRol, param);

            role.ID = (int)sp.ExecuteScalar(transaction);

            return role;
        } 

        public static void InsertRolAndFeatures(Rol role)
        {
            /* Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar un rol insertado
            sin las funcionalidades asociadas debido a un error */
            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    role = InsertRole(role, transaction);
                    FuncionalidadPersistance.InsertByRole(role, transaction);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Se produjo un error durante la insercion del rol");
                }
            }
        }

        public static void UpdateRoleAndFeatures(Rol role)
        {
            /* Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar un rol insertado
            sin las funcionalidades asociadas debido a un error */
            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    UpdateRole(role, transaction);

                    if (FuncionalidadPersistance.DeleteByRole(role, transaction) > 0)
                        if (FuncionalidadPersistance.InsertByRole(role, transaction) > 0)
                            //La unica forma que se realice la transaction: borro todas las funcionalidades viejas e inserto las nuevas
                            transaction.Commit();
                        else
                            //Tuvo que haber insertado por lo menos una, sino es un error
                            transaction.Rollback();
                    else
                        //Tuvo que haber insertado por lo menos una, sino es un error
                        transaction.Rollback();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Se produjo un error durante la modificacion del rol");
                }
            }
        }

        public static int UpdateRole(Rol role, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Rol", role.ID),
                    new SPParameter("Descripcion", role.Descripcion),
                    new SPParameter("Activo", role.Activo)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Rol.SPUpdateRolById, param, transaction)
                        : new StoreProcedure(DataBaseConst.Rol.SPUpdateRolById, param);

            return sp.ExecuteNonQuery(transaction);
        }
    }
}
