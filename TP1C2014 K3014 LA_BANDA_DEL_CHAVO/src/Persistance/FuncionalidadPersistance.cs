using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Persistance.Entities;

namespace Persistance
{
    public class FuncionalidadPersistance
    {
        public List<Funcionalidad> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidad);

            return sp.ExecuteReader<Funcionalidad>();
        }

        public List<Funcionalidad> GetByRol(Rol rol)
        {
            var param = new List<SPParameter> {new SPParameter("ID_Rol", rol.ID)};
            var sp = new StoreProcedure(DataBaseConst.Funcionalidad.SPGetAllFuncionalidadByRol, param);
            
            return sp.ExecuteReader<Funcionalidad>();
        }

        public void InsertByRol(Rol rol)
        {
            foreach (var func in rol.Funcionalidades)
            {
                var param = new List<SPParameter> { new SPParameter("ID_Funcionalidad", func.ID), new SPParameter("ID_Rol", rol.ID) };
                var sp = new StoreProcedure(DataBaseConst.Rol.SPInsertFuncionalidadXRol, param);
                
                sp.ExecuteNonQuery();
            }
        }

        public void DeleteByRol(Rol rol)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Rol", rol.ID) };
            var sp = new StoreProcedure(DataBaseConst.Rol.SPDeleteAllFuncionalidadXRol, param);

            sp.ExecuteNonQuery();
        }
    }
}
