using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class PreguntaRespuesta : IMapable
    {
        public int IdPregunta { get; set; }
        public string TextoPregunta { get; set; }
        public int IdRespuesta { get; set; }
        public string TextoRespuesta { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new PreguntaRespuesta
            {
                IdPregunta = Int32.Parse(reader["ID_Pregunta"].ToString()),
                TextoPregunta = ((String)reader["TextoPregunta"]).Trim(),
                IdRespuesta = Int32.Parse(reader["ID_Respuesta"].ToString()),
                TextoRespuesta = ((String)reader["TextoRespuesta"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
