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

        public int? IdEstadoPublicacion { get; set; }

        public int? IdVisibilidad { get; set; }

        public int? IdTipoPublicacion { get; set; }
    }
}
