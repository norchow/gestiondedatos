using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters
{
    public class PublicacionFilters
    {
        public int IdUsuario { get; set; }

        public string Descripcion { get; set; }

        public double? Precio { get; set; }

        public int? Stock { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaVencimiento { get; set; }
    }
}
