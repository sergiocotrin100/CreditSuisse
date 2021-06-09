using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class Conversion
    {
        public static int ToInt(this string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
        public static Int64 ToLong(this string value)
        {
            try
            {
                return Int64.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
        public static Int64? ToNullLong(this string value)
        {
            try
            {
                return Int64.Parse(value);
            }
            catch
            {
                return null;
            }
        }
        public static double ToDouble(this string value)
        {
            try
            {
                return double.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double? ToNullDouble(this string value)
        {
            try
            {
                return double.Parse(value);
            }
            catch
            {
                return null;
            }
        }
        public static decimal ToDecimal(this string value)
        {
            try
            {
                var valueFormated = value.Contains("R$") ? value.Replace("R$", "") : value;
                return decimal.Parse(valueFormated);
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(this string value)
        {
            try
            {
                return DateTime.ParseExact(value, "MM/dd/yyyy", new CultureInfo("en-US"));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime? ToNullDateTime(this string value)
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch
            {
                return null;
            }
        }
    }
}
