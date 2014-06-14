using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Tools
{
    public static class TypesHelper
    {
        public static bool IsNumeric(string value)
        {
            int i;
            return int.TryParse(value, out i); 
        }

        public static bool IsDecimal(string value)
        {
            double i;
            return double.TryParse(value, out i);
        }

        public static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

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
    }
}
