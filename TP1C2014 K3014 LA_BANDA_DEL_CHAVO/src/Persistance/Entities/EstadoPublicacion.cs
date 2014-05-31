using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class EstadoPublicacion : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new EstadoPublicacion
            {
                ID = Int32.Parse(reader["ID_Estado_Publicacion"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}