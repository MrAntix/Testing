using System;
using System.Collections.Generic;
using System.Linq;
using Antix.Testing.Properties;

namespace Antix.Testing
{
    public class BenchmarkResultList
    {
        readonly IEnumerable<BenchmarkResult> _results;
        readonly TimeSpan _totalTime;
        readonly int _totalIterations;
        readonly TimeSpan _average;

        public BenchmarkResultList(IEnumerable<BenchmarkResult> results)
        {
            _results = results.ToArray();

            var totalTicks = _results.Sum(r => r.Time.Ticks);
            _totalTime = TimeSpan.FromTicks(totalTicks);
            _totalIterations = _results.Sum(r => r.Iterations);

            if (_totalIterations > 0)
                _average = TimeSpan.FromTicks(totalTicks/_totalIterations);
        }

        public IEnumerable<BenchmarkResult> Results
        {
            get { return _results; }
        }

        public TimeSpan TotalTime
        {
            get { return _totalTime; }
        }

        public int TotalIterations
        {
            get { return _totalIterations; }
        }

        public TimeSpan Average
        {
            get { return _average; }
        }

        public override string ToString()
        {
            return string.Format(
                Settings.Default.BenchmarkResultList_toString,
                TotalTime, Average, TotalIterations);
        }
    }
}