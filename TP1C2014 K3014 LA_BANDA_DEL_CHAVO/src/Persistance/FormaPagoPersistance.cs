using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;

namespace Persistance
{
    public static class FormaPagoPersistance
    {
        public static List<FormaPago> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.FormaPago.SPGetAllFormaPago);
            return sp.ExecuteReader<FormaPago>();
        }

        public static FormaPago GetById(int idPaymentMethod)
        {
            return GetById(idPaymentMethod, null);
        }

        public static FormaPago GetById(int idPaymentMethod, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Forma_Pago", idPaymentMethod) };
            var sp = new StoreProcedure(DataBaseConst.FormaPago.SPGetAllFormaPagoById, param, transaction);

            var statusPublication = sp.ExecuteReaderTransactioned<FormaPago>(transaction);

            if (statusPublication == null || statusPublication.Count == 0)
                return null;

            return statusPublication[0];
        }
    }
}
