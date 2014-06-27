using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Persistance
{
    public static class ItemFacturaPersistance
    {
        public static List<ItemFactura> GetByFacturaId(int FacturaID)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Factura", FacturaID) };
            var sp = new StoreProcedure(DataBaseConst.ItemFactura.SPGetAllItemFacturaByFacturaId, param);

            var itemsFactura = sp.ExecuteReader<ItemFactura>();

            if (itemsFactura == null || itemsFactura.Count == 0)
                return null;

            return itemsFactura;
        }

        public static bool InsertItemsFactura(List<ItemFactura> itemsFactura, SqlTransaction transaction)
        {
            bool error = false;

            foreach (var item in itemsFactura)
            { 
                var newItem = InsertItemFactura(item, transaction);
                error = newItem.ID == 0;
            }

            return !error;
        }

        public static ItemFactura InsertItemFactura(ItemFactura itemFactura, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Factura", itemFactura.Factura.ID),
                    new SPParameter("ID_Publicacion", itemFactura.Publicacion.ID),
                    new SPParameter("Monto", itemFactura.Monto),
                    new SPParameter("Cantidad", itemFactura.Cantidad)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.ItemFactura.SPInsertItemFactura, param, transaction)
                        : new StoreProcedure(DataBaseConst.ItemFactura.SPInsertItemFactura, param);

            itemFactura.ID = (int)sp.ExecuteScalar(transaction);

            return itemFactura;
        }
    }
}

