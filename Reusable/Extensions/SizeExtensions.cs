using System;

namespace Reusable.SizeExtensions
{
    public static class SizeExtensions
    {
        public static string ToFileSize(this long size)
        {
            var powerToRaiseTo = (int)Math.Floor(Math.Log(size, 1024));
            return size.ToMetricString((SizeUnits)powerToRaiseTo, powerToRaiseTo);
        }

        public static string ToFileSize(this long size, SizeUnits metric)
        {
            var powerToRaiseTo = (int)metric;
            return size.ToMetricString(metric, powerToRaiseTo);
        }

        private static string ToMetricString(this long size, SizeUnits metric, int powerToRaiseTo)
        {
            var sizeInProperMetric = size / Math.Pow(1024, powerToRaiseTo);
            return sizeInProperMetric.ToString("F0") + metric.GetAbbreviation();
        }

        private static string GetAbbreviation(this SizeUnits sizeUnit)
        {
            return sizeUnit switch
            {
                SizeUnits.Byte => "B",
                SizeUnits.Kilobyte => "KB",
                SizeUnits.Megabyte => "MB",
                SizeUnits.Gigabyte => "GB",
                SizeUnits.Terabyte => "TB",
                _ => throw new ArgumentException("You managed to pass a wrong enum value!")
            };
        }

        public enum SizeUnits
        {
            Byte,
            Kilobyte,
            Megabyte,
            Gigabyte,
            Terabyte
        }
    }
}
