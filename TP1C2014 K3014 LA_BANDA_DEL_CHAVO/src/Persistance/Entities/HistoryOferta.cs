using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class HistoryOferta : IMapable
    {
        public int ID_Oferta { get; set; }
        public Double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public String Descripcion { get; set; }
        public String Ganada { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new HistoryOferta
            {
                ID_Oferta = Int32.Parse(reader["ID_Oferta"].ToString()),
                Monto = Double.Parse(reader["Monto"].ToString()),
                Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                Descripcion = ((String)reader["Descripcion"].ToString()),
                Ganada = ((String)reader["Ganada"].ToString())
            };
            

        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }



    }
}
