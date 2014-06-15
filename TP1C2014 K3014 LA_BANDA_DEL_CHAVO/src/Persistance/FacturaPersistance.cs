﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Persistance
{
    public static class FacturaPersistance
    {
        public static int GetUltimoNumeroFactura()
        {
            var sp = new StoreProcedure(DataBaseConst.Factura.SPGetUltimoNumeroFactura);

            var numeroFactura = Convert.ToInt32(sp.ExecuteReader(null));

            return numeroFactura;
        }

        public static Factura GetFacturaByPublicationId(int publicationId)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", publicationId)
                };

            var sp = new StoreProcedure(DataBaseConst.Factura.SPGetFacturaByPublicationId, param);

            var facturas = sp.ExecuteReader<Factura>();

            if (facturas == null || facturas.Count == 0)
                return null;

            facturas[0].GetObjectsById();
            return facturas[0];
        }

        public static Factura InsertFactura(Factura factura, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Numero", factura.Numero),
                    new SPParameter("Fecha", factura.Fecha),
                    new SPParameter("Total", factura.Total),
                    new SPParameter("ID_Forma_Pago", factura.FormaPago.ID),
                    new SPParameter("ID_Usuario" , factura.Usuario.ID)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Factura.SPInsertFactura, param, transaction)
                        : new StoreProcedure(DataBaseConst.Factura.SPInsertFactura, param);

            factura.ID = (int)sp.ExecuteScalar(transaction);

            return factura;
        }
    }
}
