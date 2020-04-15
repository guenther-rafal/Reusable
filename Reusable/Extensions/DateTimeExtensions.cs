using System;

namespace Reusable.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsDateEqualTo(this DateTime dateTimeToCompare, DateTime dateTimeToCompareTo)
        {
            return dateTimeToCompare.Date == dateTimeToCompareTo.Date;
        }
    }
}
