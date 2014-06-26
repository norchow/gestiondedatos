using System;
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
            var cantidades = new List<int>();
            var param = new List<SPParameter> { new SPParameter("ID_Publicacion", publicationID) };

            var sp = new StoreProcedure(DataBaseConst.Compra.SPGetCantidadComprasByPublicationIdGroupByClient, param);

            var dataReader = sp.ExecuteReader(transaction);
            while (dataReader.Read())
                cantidades.Add(Convert.ToInt32(dataReader[0]));

            if (!dataReader.IsClosed)
                dataReader.Close();

            if (cantidades.Count == 0)
                return null;

            return cantidades;
        }

        public static Compra Insert(Compra purchase, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", (purchase.Publicacion != null) ? purchase.Publicacion.ID : purchase.IdPublicacion),
                    new SPParameter("ID_Usuario", (purchase.Usuario != null) ? purchase.Usuario.ID : purchase.IdUsuario),
                    new SPParameter("Compra_Fecha", purchase.Fecha),
                    new SPParameter("Compra_Cantidad", purchase.Cantidad)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Compra.SPInsertPurchase, param, transaction)
                        : new StoreProcedure(DataBaseConst.Compra.SPInsertPurchase, param);

            purchase.ID = (int)sp.ExecuteScalar(transaction);

            return purchase;
        }


    }
}
