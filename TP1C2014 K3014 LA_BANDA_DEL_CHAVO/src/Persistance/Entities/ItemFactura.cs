using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace Persistance.Entities
{
    public class ItemFactura : IMapable
    {
        public int ID { get; set; }

        public Factura Factura { get; set; }

        public Publicacion Publicacion { get; set; }

        public double Monto { get; set; }

        public int Cantidad { get; set; }

        private int _factura;

        private int _publicacion;



        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new ItemFactura
            {
                ID = Int32.Parse(reader["ID_Factura"].ToString()),
                _factura = Convert.ToInt32(reader["ID_Factura"].ToString()),
                _publicacion = Convert.ToInt32(reader["ID_Publicacion"].ToString()),
                Monto = double.Parse(reader["Monto"].ToString()),
                Cantidad = Int32.Parse(reader["Cantidad"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}

