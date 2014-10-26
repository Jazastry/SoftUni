using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtensions
{
    public static class ExtensionsStr
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            IEnumerable<T> result = collection.Where(predicate);
            return collection.Except(result);
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            if (count < 0)
            {
                throw new IndexOutOfRangeException("Passed Invalid value to repeat-times property.");
            }
            var result = collection;
            for (int i = 1; i < count; i++)
            {
                result = result.Concat(collection);
            }
            
            return result;
        }

        public static IEnumerable<string> WhereEndsWith<T>(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            List<string> result = new List<string>();

            foreach (var item in suffixes)
            {
                var temp = collection
                    .Where(x => x.EndsWith(item))
                    .AsEnumerable<string>();

                temp.ToList<string>()
                    .ForEach(x => result.Add(x));
            }

            return result;
        }
    }
}
