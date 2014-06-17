using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Persistance.Entities;

namespace Persistance
{
    public static class FuncionalidadPersistance
    {
        public static List<Funcionalidad> GetAll()
        {
            //Obtengo todas las funcionalidades almacenadas en la base de datos
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidad);

            //Retorno una lista de Funcionalidad a partir de un ExecuteReader
            return sp.ExecuteReader<Funcionalidad>();
        }

        public static List<Funcionalidad> GetByRole(Rol role)
        {
            //Obtengo todas las funcionalidades asociadas a determinado rol
            var param = new List<SPParameter> { new SPParameter("ID_Rol", role.ID) };
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidadByRol, param);

            //Retorno una lista de Funcionalidad a partir de un ExecuteReader
            return sp.ExecuteReader<Funcionalidad>();
        }

        public static List<Funcionalidad> GetByRole(Rol role, SqlTransaction transaction)
        {
            //Obtengo todas las funcionalidades asociadas a determinado rol (transaccionado)
            var param = new List<SPParameter> { new SPParameter("ID_Rol", role.ID) };
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidadByRol, param, transaction);

            //Retorno una lista de Funcionalidad a partir de un ExecuteReader transaccionado
            return sp.ExecuteReaderTransactioned<Funcionalidad>(transaction);
        }

        public static int InsertByRole(Rol role, SqlTransaction transaction)
        {
            var regsAffected = 0;

            foreach (var feature in role.Funcionalidades)
            {
                var param = new List<SPParameter> { new SPParameter("ID_Funcionalidad", feature.ID), new SPParameter("ID_Rol", role.ID) };
                var sp = (transaction != null)
                            ? new StoreProcedure(DataBaseConst.Rol.SPInsertFuncionalidadByRol, param, transaction)
                            : new StoreProcedure(DataBaseConst.Rol.SPInsertFuncionalidadByRol, param);
                
                regsAffected += sp.ExecuteNonQuery(transaction);
            }

            //Retorno la cantidad de funcionalidades insertadas a partir de un ExecuteNonQuery
            return regsAffected;
        }

        public static int DeleteByRole(Rol role, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Rol", role.ID) };
            var sp = (transaction != null)
                            ? new StoreProcedure(DataBaseConst.Rol.SPDeleteAllFuncionalidadByRol, param, transaction)
                            : new StoreProcedure(DataBaseConst.Rol.SPDeleteAllFuncionalidadByRol, param);

            //Retorno la cantidad de funcionalidades eliminadas a partir de un ExecuteNonQuery
            return sp.ExecuteNonQuery(transaction);
        }
    }
}
