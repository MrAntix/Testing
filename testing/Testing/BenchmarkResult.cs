using System;
using Testing.Properties;

namespace Testing
{
    public class BenchmarkResult
    {
        readonly TimeSpan _time;
        readonly int _iterations;
        readonly TimeSpan _average;

        public BenchmarkResult(
            TimeSpan time, int iterations)
        {
            _time = time;
            _iterations = iterations;

            if (_iterations > 0)
                _average = TimeSpan.FromTicks(_time.Ticks/_iterations);
        }

        public TimeSpan Time
        {
            get { return _time; }
        }

        public int Iterations
        {
            get { return _iterations; }
        }

        public TimeSpan Average
        {
            get { return _average; }
        }

        public override string ToString()
        {
            return string.Format(
                Settings.Default.BenchmarkResult_toString,
                Time, Average, Iterations);
        }
    }
}