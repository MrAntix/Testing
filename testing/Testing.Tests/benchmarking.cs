using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Testing.Tests
{
    public class benchmarking
    {
        [Fact]
        void get_at_least_multiple_passed_in()
        {
            var time = Benchmark
                .Run(10, () => Thread.Sleep(1000));

            Assert.True(time.Seconds >= 10,
                string.Format("{0}", time.Seconds));
        }
    }
}