using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Reusable.Extensions
{
    public static class CurrencyExtensions
    {
        public static string ToCurrency(this decimal value)
        {
            return (string.Format(CultureInfo.CurrentCulture, "{0:C}", value));
        }

        public static string ToCurrency(this decimal value, string cultureName)
        {
            CultureInfo currentCulture = new CultureInfo(cultureName);
            return (string.Format(currentCulture, "{0:C}", value));
        }
    }
}
