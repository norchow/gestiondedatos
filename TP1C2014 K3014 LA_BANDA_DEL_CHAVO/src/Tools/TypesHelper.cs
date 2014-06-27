using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Tools
{
    public static class TypesHelper
    {
        //Valido si es un dato numerico
        public static bool IsNumeric(string value)
        {
            int i;
            return int.TryParse(value.Trim(), out i); 
        }

        //Valido si es un dato decimal
        public static bool IsDecimal(string value)
        {
            double i;
            return double.TryParse(value, out i);
        }

        //Valido si el dato es la cadena vacia
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        //Valido si el dato es una fecha valida
        public static bool IsDateTime(string value)
        {
            try
            {
                var i = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Valido si el dato es un CUIT/CUIL valido
        public static bool IsCUITValid(string value)
        {
            if (value.Length == 0) return false;

			var CUITValidado = string.Empty;
			bool Valido = false;

			for(int i = 0; i < value.Length; i++)
			{
                var Ch = value[i];
				if ((Ch > 47) && (Ch < 58))
				{
					CUITValidado = CUITValidado + Ch;
				}
			}

            value = CUITValidado;
            Valido = (value.Length == 11);
			if (Valido)
			{
                int Verificador = FindVerifier(value);
                Valido = (value[10].ToString() == Verificador.ToString());
			}
 
			return Valido;
        }

        //Obtengo el digito verificador del CUIT/CUIL
        private static int FindVerifier(string CUIT)
        {
            int Sumador = 0;
            int Producto = 0;
            int Coeficiente = 0;
            int Resta = 5;
            for (int i = 0; i < 10; i++)
            {
                if (i == 4) Resta = 11;
                Producto = CUIT[i];
                Producto -= 48;
                Coeficiente = Resta - i;
                Producto = Producto * Coeficiente;
                Sumador = Sumador + Producto;
            }

            int Resultado = Sumador - (11 * (Sumador / 11));
            Resultado = 11 - Resultado;

            if (Resultado == 11) return 0;
            else return Resultado;
        }		
    }
}
