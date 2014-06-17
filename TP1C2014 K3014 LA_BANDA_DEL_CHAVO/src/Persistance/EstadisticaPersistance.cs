using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;
using Filters;

namespace Persistance
{
    public static class EstadisticaPersistance
    {
        public static List<Estadistica> GetSellersWithMoreProductsNotSold(EstadisticaFilters filters)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filters.FechaDesde),
                new SPParameter("Fecha_Hasta", filters.FechaHasta),
                new SPParameter("Visibilidad", filters.Visibilidad ?? (object)DBNull.Value)
            };
            var sp = new StoreProcedure(DataBaseConst.Estadistica.SPGetSellersWithMoreProductsNotSold, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> GetSellersWithMoreBilling(EstadisticaFilters filters)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filters.FechaDesde),
                new SPParameter("Fecha_Hasta", filters.FechaHasta)
            };
            var sp = new StoreProcedure(DataBaseConst.Estadistica.SPGetSellersWithMoreBilling, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> GetClientsWithMoreNotQualifiedPublications(EstadisticaFilters filters)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filters.FechaDesde),
                new SPParameter("Fecha_Hasta", filters.FechaHasta)
            };
            var sp = new StoreProcedure(DataBaseConst.Estadistica.SPGetClientsWithMoreNotQualifiedPublications, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> GetSellersWithBetterQualifications(EstadisticaFilters filters)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filters.FechaDesde),
                new SPParameter("Fecha_Hasta", filters.FechaHasta)
            };
            var sp = new StoreProcedure(DataBaseConst.Estadistica.SPGetSellersWithBetterQualifications, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }
    }
}
