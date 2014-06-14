using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Persistance.Entities;

namespace Persistance.Entities
{
    public class PublicacionNotCalified : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }


        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new PublicacionNotCalified
            {
                ID = Int32.Parse(reader["ID_Publicacion"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim(),
                Precio = ((String)reader["Precio"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
