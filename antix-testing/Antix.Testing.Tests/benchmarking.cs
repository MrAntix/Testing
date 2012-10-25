using System;
using System.Threading;
using Xunit;

namespace Antix.Testing.Tests
{
    public class benchmarking
    {
        [Fact]
        void action_required()
        {
            Assert.Throws<ArgumentNullException>(
                () => Benchmark
                          .Run(default(Action))
                );
        }

        [Fact]
        void get_at_least_multiple_passed_in()
        {
            var result = Benchmark
                .Run(() => Thread.Sleep(1), 10);

            Console.Write(result);

            Assert.True(result.Time.Milliseconds >= 10,
                        string.Format("{0}", result.Time));
        }

        [Fact]
        void get_at_least_multiple_passed_in_when_multiple()
        {
            var result = Benchmark
                .Run(() => Thread.Sleep(1), 10, 20);

            Console.Write(result);

            Assert.True(result.TotalTime.Milliseconds >= 30,
                        string.Format("{0}", result.TotalTime));
        }

        [Fact]
        void call_with_null_iterations()
        {
            Assert.Throws<ArgumentNullException>(
                () => Benchmark
                          .Run(() => { }, default(int[]))
                );
        }

        [Fact]
        void call_with_iterations_not_passed()
        {
            var result = Benchmark
                .Run(() => { });

            Assert.Equal(0, result.Average.Ticks);
            Assert.Equal(0, result.TotalTime.Ticks);
            Assert.Equal(0, result.TotalIterations);
        }

        [Fact]
        void zero_or_negative_stop_iterations_gives_error()
        {
            const int iterations = -1;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => Benchmark
                          .Run(() => Thread.Sleep(1), iterations)
                );
        }

        [Fact]
        void time_not_less_than_stop()
        {
            var stopAfter = TimeSpan.FromMilliseconds(50);
            var result = Benchmark
                .Run(() => Thread.Sleep(1), stopAfter);

            Console.Write(result);

            Assert.True(result.Time >= stopAfter,
                        string.Format("{0}", result.Time));
        }

        [Fact]
        void zero_or_negative_stop_time_gives_error()
        {
            var stopAfter = TimeSpan.FromMilliseconds(-100);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => Benchmark
                          .Run(() => Thread.Sleep(1), stopAfter)
                );
        }
    }
}