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

            return OneOfNoCheck(items);
        }

        static T OneOfNoCheck<T>(IEnumerable<T> items)
        {
            return items.ElementAt(
                Random.Next(items.Count()));
        }

        public static IEnumerable<T> ManyOf<T>(this IEnumerable<T> items, int count)
        {
            if (items == null) throw new ArgumentNullException("items");

            return Enumerable.Range(0, count).Select(i => OneOfNoCheck(items));
        }
    }
}