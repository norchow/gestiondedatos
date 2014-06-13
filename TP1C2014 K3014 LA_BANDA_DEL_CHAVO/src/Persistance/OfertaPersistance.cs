using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using Filters;
using Configuration;

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




    }
}
