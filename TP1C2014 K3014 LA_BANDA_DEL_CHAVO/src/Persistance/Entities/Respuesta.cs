using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Respuesta : IMapable
    {
        public int ID { get; set; }
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        public bool Efectiva { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Respuesta
            {
                ID = Int32.Parse(reader["ID_Respuesta"].ToString()),
                IdPregunta = Int32.Parse(reader["ID_Pregunta"].ToString()),
                Texto = ((String)reader["Texto"]).Trim(), 
                Efectiva = Boolean.Parse(reader["Efectiva"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
