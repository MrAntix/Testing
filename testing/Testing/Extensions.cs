using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    public static class Extensions
    {
        public static T OneOf<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return OneOfNoCheck(items.ToArray());
        }

        static T OneOfNoCheck<T>(T[] itemsArray)
        {
            return itemsArray[Data.Random.Value.Next(0, itemsArray.Length)];
        }

        public static IEnumerable<T> ManyOf<T>(
            this IEnumerable<T> items, int exactCount)
        {
            if (items == null) throw new ArgumentNullException("items");
            var itemsArray = items.ToArray();

            return Enumerable.Range(0, exactCount)
                .Select(i => OneOfNoCheck(itemsArray));
        }

        public static IEnumerable<T> ManyOf<T>(
            this IEnumerable<T> items, int minCount, int maxCount)
        {
            if (items == null) throw new ArgumentNullException("items");
            var itemsArray = items.ToArray();

            return Enumerable
                .Range(0, Data.Random.Value.Next(minCount, maxCount))
                .Select(i => OneOfNoCheck(itemsArray));
        }
    }
}