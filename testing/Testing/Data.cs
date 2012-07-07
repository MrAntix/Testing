using System;
using System.Threading;

namespace Testing
{
    public sealed class Data
    {
        static int _randomSeed = Environment.TickCount;

        // http://csharpindepth.com/Articles/Chapter12/Random.aspx
        internal static readonly ThreadLocal<Random> Random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _randomSeed)));

        internal static readonly ThreadLocal<Data> Local =
            new ThreadLocal<Data>(
                () =>
                new Data
                    {
                        _container = new DataContainer(new DataResources())
                    }
                );

        DataContainer _container;

        public static DataContainer Container
        {
            get { return Local.Value._container; }
        }
    }
}