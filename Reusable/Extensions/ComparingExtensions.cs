using System;

namespace Reusable.Extensions
{
    public static class ComparingExtensions
    {
        public static bool Between<T>(this T actual, T greaterThan, T lesserThan) where T : IComparable<T>
        {
            return actual.CompareTo(greaterThan) > 0 && actual.CompareTo(lesserThan) < 0;
        }

        public static bool BetweenInclusive<T>(this T actual, T greaterOrEqualTo, T lesserOrEqualTo) where T : IComparable<T>
        {
            return actual.CompareTo(greaterOrEqualTo) >= 0 && actual.CompareTo(lesserOrEqualTo) <= 0;
        }

        public static bool BetweenRightOpen<T>(this T actual, T greaterOrEqualTo, T lesserThan) where T : IComparable<T>
        {
            return actual.CompareTo(greaterOrEqualTo) >= 0 && actual.CompareTo(lesserThan) < 0;
        }

        public static bool BetweenLeftOpen<T>(this T actual, T greaterThan, T lesserOrEqualTo) where T : IComparable<T>
        {
            return actual.CompareTo(greaterThan) > 0 && actual.CompareTo(lesserOrEqualTo) <= 0;
        }
    }
}
