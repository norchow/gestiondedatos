using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Pregunta : IMapable
    {
        public int ID { get; set; }
        public int IdPublicacion { get; set; }
        public string Texto { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Pregunta
            {
                ID = Int32.Parse(reader["ID_Pregunta"].ToString()),
                IdPublicacion = Int32.Parse(reader["ID_Publicacion"].ToString()),
                Texto = ((String)reader["Texto"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
