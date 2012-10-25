namespace Antix.Testing
{
    public interface IBenchmark
    {
        BenchmarkResultList Run(
            params int[] moreIterations);

        BenchmarkResult Run(
            int iterations);
    }
}