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
            if (iterations <= 0) throw new ArgumentOutOfRangeException("iterations");

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

        public BenchmarkResult Run(
            TimeSpan stopAfter)
        {
            if (stopAfter.Ticks <= 0) throw new ArgumentOutOfRangeException("stopAfter");

            ClearDown();

            var iterations = 0;

            _action();

            var watch = Stopwatch.StartNew();
            while (stopAfter > watch.Elapsed)
            {
                _action();
                iterations++;
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

        public static BenchmarkResult Run(
            Action action, TimeSpan stopAfter)
        {
            var benchmark = new Benchmark(action);

            return benchmark.Run(stopAfter);
        }
    }
}