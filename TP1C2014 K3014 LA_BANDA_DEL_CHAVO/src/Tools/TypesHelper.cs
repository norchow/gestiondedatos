using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
