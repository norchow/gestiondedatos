using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace Persistance.Entities
{
    public class Factura : IMapable
    {
        public int ID { get; set; }

        public long Numero { get; set; }

        public DateTime Fecha { get; set; }
        
        public double Total { get; set; }

        public FormaPago FormaPago { get; set; }

        public List<ItemFactura> ItemsFactura { get; set; }

        public Usuario Usuario { get; set; }

        private int _idFormaPago;

        private int _idUsuario;

        public Factura()
        {
            ItemsFactura = new List<ItemFactura>();
        }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Factura
            {
                ID = Int32.Parse(reader["ID_Factura"].ToString()),
                Numero = long.Parse(reader["Numero"].ToString()),
                Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                Total = double.Parse(reader["Total"].ToString()),
                _idFormaPago = Convert.ToInt32(reader["ID_Forma_Pago"].ToString()),
                _idUsuario = Convert.ToInt32(reader["ID_Usuario"].ToString()),
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }

        public void GetObjectsById()
        {
            ItemsFactura = ItemFacturaPersistance.GetByFacturaId(ID);
            FormaPago = FormaPagoPersistance.GetById(_idFormaPago);
            Usuario = UsuarioPersistance.GetById(_idUsuario);
        }
    }
}

