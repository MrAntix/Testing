using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Testing
{
    public static class Extensions
    {
        static int _randomSeed = Environment.TickCount;

        // http://csharpindepth.com/Articles/Chapter12/Random.aspx
        static readonly ThreadLocal<Random> LocalRandom =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _randomSeed)));

        public static Random Random
        {
            get { return LocalRandom.Value; }
        }

        public static T OneOf<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return OneOfNoCheck(items.ToArray());
        }

        static T OneOfNoCheck<T>(T[] itemsArray)
        {
            return itemsArray[
                Random.Next(itemsArray.Count())];
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

            return Enumerable.Range(0, Random.Next(minCount, maxCount))
                .Select(i => OneOfNoCheck(itemsArray));
        }
    }
}