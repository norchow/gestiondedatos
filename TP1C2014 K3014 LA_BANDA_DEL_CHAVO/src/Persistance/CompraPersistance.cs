﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Filters;

namespace Persistance
{
    public class CompraPersistance
    {

        public static List<HistoryCompra> GetAllCompras(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID) };
            var sp = new StoreProcedure(DataBaseConst.Compra.SPGetHistoryComprasByUsuario, param);
            return sp.ExecuteReader<HistoryCompra>();
        }

        public static List<HistoryCompra> GetAllComprasByParameters(Usuario user, HistoryCompraFilters filter)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                                                new SPParameter("ID_Compra", filter.Codigo ?? (object)DBNull.Value),
                                                new SPParameter("Descripcion", filter.Descripcion ?? (object)DBNull.Value) ,
                                                 new SPParameter("Precio", filter.Precio ?? (object)DBNull.Value),
                                                 new SPParameter("Compra_Cantidad", filter.Cantidad ?? (object)DBNull.Value),
                                                 new SPParameter("Compra_Fecha", filter.Fecha?? (object)DBNull.Value)
            };
            var sp = new StoreProcedure(DataBaseConst.Compra.SPGetHistoryComprasByUsuarioByParameters, param);
            return sp.ExecuteReader<HistoryCompra>();
        }

        public static List<HistoryCompra> GetAllComprasByParametersLike(Usuario user, HistoryCompraFilters filter)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                                                new SPParameter("ID_Compra", filter.Codigo ?? (object)DBNull.Value),
                                                new SPParameter("Descripcion", filter.Descripcion ?? (object)DBNull.Value) ,
                                                 new SPParameter("Precio", filter.Precio ?? (object)DBNull.Value),
                                                 new SPParameter("Compra_Cantidad", filter.Cantidad ?? (object)DBNull.Value),
                                                 new SPParameter("Compra_Fecha", filter.Fecha?? (object)DBNull.Value)
            };
            var sp = new StoreProcedure(DataBaseConst.Compra.SPGetHistoryComprasByUsuarioByParametersLike, param);
            return sp.ExecuteReader<HistoryCompra>();
        }

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