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
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidad);

            return sp.ExecuteReader<Funcionalidad>();
        }

        public static List<Funcionalidad> GetByRole(Rol role)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Rol", role.ID) };
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidadByRol, param);
            
            return sp.ExecuteReader<Funcionalidad>();
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

            return regsAffected;
        }

        public static int DeleteByRole(Rol role, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Rol", role.ID) };
            var sp = (transaction != null)
                            ? new StoreProcedure(DataBaseConst.Rol.SPDeleteAllFuncionalidadByRol, param, transaction)
                            : new StoreProcedure(DataBaseConst.Rol.SPDeleteAllFuncionalidadByRol, param);

            return sp.ExecuteNonQuery(transaction);
        }
    }
}
