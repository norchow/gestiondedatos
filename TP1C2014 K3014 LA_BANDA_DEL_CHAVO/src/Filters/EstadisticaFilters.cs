using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters
{
    public class EstadisticaFilters
    {
        public string FechaDesde { get; set; }

        public string FechaHasta { get; set; }

        public int TipoEstadistica { get; set; }

        public int? Visibilidad { get; set; }

    }
}
