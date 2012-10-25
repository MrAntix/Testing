using System;
using System.Diagnostics;
using System.Linq;

namespace Antix.Testing
{
    public class Benchmark : IBenchmark
    {
        readonly Action _action;

        public Benchmark(Action action)
        {
            if (action == null) throw new ArgumentNullException("action");

            _action = action;
        }

        public BenchmarkResultList Run(
            params int[] moreIterations)
        {
            if (moreIterations == null)
                throw new ArgumentNullException("moreIterations");

            return new BenchmarkResultList(
                moreIterations.Select(Run));
        }

        public BenchmarkResult Run(
            int iterations)
        {
            ClearDown();

            _action();

            var watch = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _action();
            }
            watch.Stop();

            return new BenchmarkResult(watch.Elapsed, iterations);
        }

        static void ClearDown()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static BenchmarkResultList Run(
            Action action, params int[] iterationsList)
        {
            var benchmark = new Benchmark(action);

            return benchmark.Run(iterationsList);
        }

        public static BenchmarkResult Run(
            Action action, int iterations)
        {
            var benchmark = new Benchmark(action);

            return benchmark.Run(iterations);
        }
    }
}