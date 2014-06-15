using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Oferta : IMapable
    {
        public int ID { get; set; }
        public int IdCliente { get; set; }
        public int IdPublicacion { get; set; }
        public Double Monto { get; set; }
        public DateTime Fecha { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Oferta
            {
                ID = Int32.Parse(reader["ID_Oferta"].ToString()),
                IdCliente = Int32.Parse(reader["ID_Cliente"].ToString()),
                IdPublicacion = Int32.Parse(reader["ID_Publicacion"].ToString()),
                Monto = Double.Parse(reader["Monto"].ToString()),
                Fecha = DateTime.Parse(reader["Fecha"].ToString())
            };


        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
