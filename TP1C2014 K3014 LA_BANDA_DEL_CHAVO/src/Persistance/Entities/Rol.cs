using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Rol : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        private List<Funcionalidad> _funcionalidades { get; set; }

        public List<Funcionalidad> Funcionalidades
        {
            get { return _funcionalidades ?? (_funcionalidades = FuncionalidadPersistance.GetByRole(this)); }
            set { _funcionalidades = value; }
        }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Rol
                {
                    ID = Int32.Parse(reader["ID_Rol"].ToString()),
                    Descripcion = ((String)reader["Descripcion"]).Trim(),
                    Activo = bool.Parse(reader["Activo"].ToString())
                };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
