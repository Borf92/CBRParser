using System;
using System.Globalization;

namespace CBRParser
{
    public static class ConvertTypeHelper
    {
        private static readonly Logger Logger = new Logger();

        public static string ToStingWithDot(this decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static decimal ToDecimalWithInvariantCulture(this string value)
        {
            try
            {
                return Decimal.Parse(
                    value.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator),
                    NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return 0;
            }
        }
    }
}
