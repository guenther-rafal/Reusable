using System;

namespace Reusable.Extensions
{
    public static class ArgumentExtensions
    {
        public static void ThrowIfNull<TObject>(this TObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void ThrowIfNull<TObject>(this TObject obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name, $"Argument {name} cannot be null!");
            }
        }

        public static void ThrowIfNull<TObject>(this TObject obj, string name, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name, message);
            }
        }
    }
}
