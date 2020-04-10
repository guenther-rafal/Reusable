using System.Collections.Generic;

namespace SmartFillCommon.Extension
{
    public static class GenericExtensions
    {
        public static List<TObject> Enlist<TObject>(this TObject obj)
        {
            return new List<TObject>
            { 
                obj
            };
        }
    }
}
