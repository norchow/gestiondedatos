using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance.Entities
{
    public class TarjetaCredito
    {
        public int ID { get; set; }

        public string Tarjeta { get; set; }

        public int NumeroTarjeta { get; set; }

        public int Vencimiento { get; set; }

        public int CodigoSeguridad { get; set; }

        public string Titular { get; set; }

        public int DniTitular { get; set; }

        public Factura Factura { get; set; }
    }
}
