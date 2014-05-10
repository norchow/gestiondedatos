using System;
using System.Collections.Generic;
using Persistance.Entities;

namespace Persistance
{
    public class RolPersistance
    {
        public List<Rol> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetAllRol);
            return sp.ExecuteReader<Rol>();
        }

        public List<Rol> GetByUser(Usuario usuario)
        {
            var param = new List<SPParameter> {new SPParameter("ID_User", usuario.ID)};
            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetAllRolByUser, param);

            return sp.ExecuteReader<Rol>();
        }

        public Rol GetByNombre(String descripcion, bool habilitados)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", descripcion), 
                    new SPParameter("Habilitados", habilitados)
                };

            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetRolByName, param);

            var roles = sp.ExecuteReader<Rol>();

            if (roles == null || roles.Count == 0)
                return null;

            return roles[0];
        }

        public List<Rol> GetByNombreLike(String descripcion, bool habilitados)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", descripcion),
                    new SPParameter("Habilitados", habilitados)
                };

            var sp = new StoreProcedure(DataBaseConst.Rol.SPGetAllRolByNameLike, param);

            return sp.ExecuteReader<Rol>();
        }

        public Rol InsertRol(Rol rol)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", rol.Descripcion), 
                    new SPParameter("Habilitados", rol.Activo)
                };

            var sp = new StoreProcedure(DataBaseConst.Rol.SPInsertRol, param);
            rol.ID = int.Parse(sp.ExecuteScalar().ToString());

            return rol;
        }

        public void UpdateRol(Rol rol)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Rol", rol.ID),
                    new SPParameter("Descripcion", rol.Descripcion),
                    new SPParameter("Habilitado", rol.Activo)
                };
            var sp = new StoreProcedure(DataBaseConst.Rol.SPUpdateRolById, param);

            sp.ExecuteNonQuery();
        }
    }
}
