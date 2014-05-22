using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Visibilidad : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public double PrecioPublicar { get; set; }
        public double PorcentajeVenta { get; set; }
        public int Duracion { get; set; }
        public bool Activo { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Visibilidad
            {
                ID = Int32.Parse(reader["ID_Visibilidad"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim(),
                PrecioPublicar = double.Parse(reader["Precio_Publicar"].ToString()),
                PorcentajeVenta = double.Parse(reader["Porcentaje_Venta"].ToString()),
                Duracion = Int32.Parse(reader["Duracion"].ToString()),
                Activo = bool.Parse(reader["Activo"].ToString()),
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
