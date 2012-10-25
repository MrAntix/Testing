using System;
using System.Threading;
using Xunit;

namespace Testing.Tests
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
                          .Run(() => { }, null)
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
    }
}