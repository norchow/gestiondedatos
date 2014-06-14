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
    public static class CompraPersistance
    {
        public static List<Compra> GetByPublicationId(int publicationID)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Publicacion", publicationID) };
            var sp = new StoreProcedure(DataBaseConst.Compra.SPGetAllCompraByPublicationId, param);

            var compras = sp.ExecuteReader<Compra>();

            if (compras == null || compras.Count == 0)
                return null;

            return compras;
        }

        public static List<int> GetCantidadComprasByPublicationIdGroupByClient(int publicationID, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Publicacion", publicationID) };

            var sp = new StoreProcedure(DataBaseConst.Compra.SPGetCantidadComprasByPublicationIdGroupByClient, param);

            //var cantidades = (List<int>)sp.ExecuteReader(transaction);

            //if (cantidades == null || cantidades.Count == 0)
            //    return null;

            //return cantidades;

            return null;
        }
    }
}

