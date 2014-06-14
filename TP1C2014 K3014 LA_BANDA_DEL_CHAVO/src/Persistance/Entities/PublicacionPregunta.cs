using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class PublicacionPregunta : IMapable
    {
        public int ID_Publicacion;
        public String Descripcion;
        public int ID_Pregunta;
        public String Texto;

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new PublicacionPregunta
            {
                ID_Publicacion = Int32.Parse(reader["ID_Publicacion"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim(),
                ID_Pregunta = Int32.Parse(reader["ID_Pregunta"].ToString()),
                Texto = ((String)reader["Texto"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
