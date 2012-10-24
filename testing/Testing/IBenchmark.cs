using System;

namespace Testing
{
    public interface IBenchmark
    {
        TimeSpan Run(int iterations);
    }
}