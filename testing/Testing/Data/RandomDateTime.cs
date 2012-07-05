using System;

namespace Testing.Data
{
    public class RandomDateTime :
        RandomBase<DateTime>
    {
        public RandomDateTime() :
            base(DateTime.MinValue, DateTime.MaxValue)
        {
        }

        public override DateTime Get(DateTime min, DateTime max)
        {
            var minTicks = min.Ticks;
            var maxTicks = max.Ticks;

            return new DateTime(
                (long) (minTicks + Random.Local.Value.NextDouble()*(maxTicks - minTicks))
                );
        }
    }
}