using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Reusable.Extension
{
    public static class CollectionExtensions
    {
        public static ICollection<TObject> Enlist<TObject>(this TObject obj)
        {
            return new List<TObject>
            { 
                obj
            };
        }

        public static void AddRange<TObject>(this ICollection<TObject> collection, params TObject[] rangeToAdd)
        {
            foreach(var obj in rangeToAdd)
            {
                collection.Add(obj);
            }
        }

        public static bool IsIn<TObject>(this TObject obj, params TObject[] collection)
        {
            return collection.Contains(obj);
        }
    }
}
