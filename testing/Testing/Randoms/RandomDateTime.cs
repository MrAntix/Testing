using System;

namespace Testing.Randoms
{
    public class RandomDateTime :
        RandomBase<DateTime, DateTime>
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
                (long) (minTicks + Data.Random.Value.NextDouble()*(maxTicks - minTicks))
                );
        }
    }
}