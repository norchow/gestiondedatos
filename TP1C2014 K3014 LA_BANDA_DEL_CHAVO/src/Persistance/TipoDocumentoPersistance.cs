﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Persistance
{
    public static class TipoDocumentoPersistance
    {
        public static List<TipoDocumento> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.TipoDocumento.SPGetAllTipoDocumento);
            return sp.ExecuteReader<TipoDocumento>();
        }

        public static List<TipoDocumento> GetAll(SqlTransaction transaction)
        {
            var sp = new StoreProcedure(DataBaseConst.TipoDocumento.SPGetAllTipoDocumento, null, transaction);
            return sp.ExecuteReaderTransactioned<TipoDocumento>(transaction);
        }
    }
}
