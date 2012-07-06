using System;
using System.Threading;
using Testing.Randoms;

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
                    {
                        var container = new DataResources();
                        return new Data
                                   {
                                       _resources = container,
                                       _randomByte = new RandomByte(),
                                       _randomShort = new RandomShort(),
                                       _randomInteger = new RandomInteger(),
                                       _randomDateTime = new RandomDateTime(),
                                       _randomString = new RandomString(container)
                                   };
                    });

        RandomByte _randomByte;
        RandomDateTime _randomDateTime;
        RandomInteger _randomInteger;
        RandomShort _randomShort;
        RandomString _randomString;
        DataResources _resources;

        public static DataResources Resources
        {
            get { return Local.Value._resources; }
        }

        public static RandomByte RandomByte
        {
            get { return Local.Value._randomByte; }
        }

        public static RandomShort RandomShort
        {
            get { return Local.Value._randomShort; }
        }

        public static RandomInteger RandomInteger
        {
            get { return Local.Value._randomInteger; }
        }

        public static RandomDateTime RandomDateTime
        {
            get { return Local.Value._randomDateTime; }
        }

        public static RandomString RandomString
        {
            get { return Local.Value._randomString; }
        }
    }
}