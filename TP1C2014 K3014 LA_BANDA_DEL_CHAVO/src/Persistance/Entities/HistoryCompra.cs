using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class HistoryCompra : IMapable
    {
        public int ID_Compra { get; set; }
        public String Descripcion { get; set; }
        public DateTime Compra_Fecha { get; set; }
        public double Precio { get; set; }
        public int Compra_Cantidad { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new HistoryCompra
            {
                ID_Compra = Int32.Parse(reader["ID_Compra"].ToString()),
                Descripcion = ((String)reader["Descripcion"].ToString()),
                Compra_Fecha = DateTime.Parse(reader["Compra_Fecha"].ToString()),
                Precio = Double.Parse(reader["Precio"].ToString()),
                Compra_Cantidad = Int32.Parse(reader["Compra_Cantidad"].ToString())

            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }

    }
}
