using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using Filters;
using Configuration;
using System.Data.SqlClient;

namespace Persistance
{
    public class OfertaPersistance
    {
        public static List<HistoryOferta> GetAllOfertasByUsuario(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                                                new SPParameter("Fecha_hoy", ConfigurationVariables.FechaSistema)};
            var sp = new StoreProcedure(DataBaseConst.Oferta.SPGetHistoryOfertasByUsuario, param);
            return sp.ExecuteReader<HistoryOferta>();
        }

        public static List<HistoryOferta> GetAllOfertasByUsuarioByParameters(Usuario user, HistoryOfertaFilters filter)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                                                new SPParameter("Fecha_hoy", ConfigurationVariables.FechaSistema),
                                                new SPParameter("ID_Oferta", filter.Codigo ?? (object)DBNull.Value),
                                                new SPParameter("Monto", filter.Monto ?? (object)DBNull.Value) ,
                                                 new SPParameter("Fecha", filter.Fecha ?? (object)DBNull.Value),
                                                 new SPParameter("Descripcion", filter.Descripcion ?? (object)DBNull.Value),
                                                 new SPParameter("Ganada", filter.Ganada?? (object)DBNull.Value)
            };
            var sp = new StoreProcedure(DataBaseConst.Oferta.SPGetHistoryOfertasByUsuarioByParameters, param);
            return sp.ExecuteReader<HistoryOferta>();
        }

        public static List<HistoryOferta> GetAllOfertasByUsuarioByParametersLike(Usuario user, HistoryOfertaFilters filter)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                                                new SPParameter("Fecha_hoy", ConfigurationVariables.FechaSistema),
                                                new SPParameter("ID_Oferta", filter.Codigo ?? (object)DBNull.Value),
                                                new SPParameter("Monto", filter.Monto ?? (object)DBNull.Value) ,
                                                 new SPParameter("Fecha", filter.Fecha ?? (object)DBNull.Value),
                                                 new SPParameter("Descripcion", filter.Descripcion ?? (object)DBNull.Value),
                                                 new SPParameter("Ganada", filter.Ganada?? (object)DBNull.Value)
            };
            var sp = new StoreProcedure(DataBaseConst.Oferta.SPGetHistoryOfertasByUsuarioByParametersLike, param);
            return sp.ExecuteReader<HistoryOferta>();
        }

        public static Oferta GetLastOfertaByPublication(int idPublicacion)
        {
            return GetLastOfertaByPublication(idPublicacion, null);
        }

        public static Oferta GetLastOfertaByPublication(int idPublicacion, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("idPublicacion", idPublicacion)};
            var sp = new StoreProcedure(DataBaseConst.Oferta.SPGetLastOfertaByPublication, param, transaction);

            var offers = (transaction == null) ? sp.ExecuteReader<Oferta>() : sp.ExecuteReaderTransactioned<Oferta>(transaction);
            if (offers == null || offers.Count == 0)
                return null;

            return offers[0];
        }

        public static Oferta Insert(Oferta offer, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", offer.IdPublicacion),
                    new SPParameter("ID_Usuario", offer.IdUsuario),
                    new SPParameter("Monto", offer.Monto),
                    new SPParameter("Fecha", offer.Fecha)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Oferta.SPInsertOffer, param, transaction)
                        : new StoreProcedure(DataBaseConst.Oferta.SPInsertOffer, param);

            offer.ID = (int)sp.ExecuteScalar(transaction);

            return offer;
        }




    }
}
