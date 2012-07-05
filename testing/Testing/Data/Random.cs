using System;
using System.Threading;

namespace Testing.Data
{
    public static class Random
    {
        static int _randomSeed = Environment.TickCount;

        // http://csharpindepth.com/Articles/Chapter12/Random.aspx
        internal static readonly ThreadLocal<System.Random> Local =
            new ThreadLocal<System.Random>(() => new System.Random(Interlocked.Increment(ref _randomSeed)));

        public static RandomByte Byte = new RandomByte();
        public static RandomShort Short = new RandomShort();
        public static RandomInteger Integer = new RandomInteger();
        public static RandomDateTime DateTime = new RandomDateTime();
    }
}