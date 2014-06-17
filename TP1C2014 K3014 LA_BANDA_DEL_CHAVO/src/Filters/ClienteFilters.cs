using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters
{
    public class ClienteFilters
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int? TipoDocumento { get; set; }

        public int? NroDocumento { get; set; }

        public string Email { get; set; }
    }
}
