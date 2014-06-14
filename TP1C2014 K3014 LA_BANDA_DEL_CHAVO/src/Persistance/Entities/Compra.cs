using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace Persistance.Entities
{
    public class Compra : IMapable
    {
        public int ID { get; set; }

        public Publicacion Publicacion { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public int Cantidad { get; set; }

        private int _publicacion;

        private int _cliente;

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Compra
            {
                ID = Int32.Parse(reader["ID_Compra"].ToString()),
                _publicacion = Convert.ToInt32(reader["ID_Publicacion"].ToString()),
                _cliente = Convert.ToInt32(reader["ID_Cliente"].ToString()),
                Fecha = DateTime.Parse(reader["Compra_Fecha"].ToString()),
                Cantidad = int.Parse(reader["Compra_Cantidad"].ToString())               
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}

