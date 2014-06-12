using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class HistoryReputacion : IMapable
    {
        public int Codigo_Calificacion { get; set; }
        public String Descripcion { get; set; }
        public String Nombre { get; set; }
        public int Cantidad_Estrellas { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new HistoryReputacion
            {
                Codigo_Calificacion = Int32.Parse(reader["Codigo_Calificacion"].ToString()),
                Descripcion = ((String)reader["Descripcion"].ToString()),
                                Cantidad_Estrellas = Int32.Parse(reader["Cantidad_Estrellas"].ToString()),
                Nombre = ((String)reader["Nombre"].ToString())


            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }

    }
}
