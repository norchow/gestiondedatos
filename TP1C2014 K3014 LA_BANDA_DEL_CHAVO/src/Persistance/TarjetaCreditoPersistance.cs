using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;

namespace Persistance
{
    public class TarjetaCreditoPersistance
    {
        public static TarjetaCredito Insert(TarjetaCredito tarjetaCredito, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Codigo_Seguridad", tarjetaCredito.CodigoSeguridad),
                    new SPParameter("Dni_Titular", tarjetaCredito.DniTitular),
                    new SPParameter("ID_Factura", tarjetaCredito.Factura.ID),
                    new SPParameter("Numero_Tarjeta", tarjetaCredito.NumeroTarjeta),
                    new SPParameter("Tarjeta", tarjetaCredito.Tarjeta),
                    new SPParameter("Titular", tarjetaCredito.Titular),
                    new SPParameter("Vencimiento", tarjetaCredito.Vencimiento)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.TarjetaCredito.SPInsertCreditCard, param, transaction)
                        : new StoreProcedure(DataBaseConst.TarjetaCredito.SPInsertCreditCard, param);

            tarjetaCredito.ID = (int)sp.ExecuteScalar(transaction);

            return tarjetaCredito;
        }
    }
}