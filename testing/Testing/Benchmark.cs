using System;
using System.Diagnostics;

namespace Testing
{
    public class Benchmark : IBenchmark
    {
        readonly Action _action;

        public Benchmark(Action action)
        {
            _action = action;
        }

        public TimeSpan Run(int iterations)
        {
            ClearDown();

            _action();

            var watch = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _action();
            }
            watch.Stop();

            return watch.Elapsed;
        }

        static void ClearDown()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static TimeSpan Run(int iterations, Action action)
        {
            var benchmark = new Benchmark(action);

            return benchmark.Run(iterations);
        }
    }
}