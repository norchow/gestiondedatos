using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Usuario : IMapable
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public bool Habilitado { get; set; }
        public bool PassTemporal { get; set; }
        public int LoginFails { get; set; }
        private List<Rol> _roles { get; set; }

        public List<Rol> Roles
        {
            get { return _roles ?? (_roles = RolPersistance.GetByUser(this)); }
            set { _roles = value; }
        }

        public List<Rol> RolesActivos
        {
            get 
            {
                if (_roles == null)
                    _roles = RolPersistance.GetByUser(this);

                return _roles.FindAll(rol => rol.Activo); 
            }
        }

        public IMapable Map(SqlDataReader reader)
        {
            return new Usuario
                {
                    ID = Int32.Parse(reader["ID_Usuario"].ToString()),
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString(),
                    Activo = bool.Parse(reader["Activo"].ToString()),
                    Habilitado = bool.Parse(reader["Habilitado"].ToString()),
                    PassTemporal = bool.Parse(reader["Pass_Temporal"].ToString()),
                    LoginFails = int.Parse(reader["Intentos_Fallidos"].ToString())
                };
        }

        public List<SPParameter> UnMap(IMapable entity) { return new List<SPParameter>(); }
    }
}
