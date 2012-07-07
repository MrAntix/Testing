using System;
using Testing.Base;

namespace Testing.Builders
{
    public class DateTimeBuilder :
        ValueBuilderBase<DateTime, DateTime>
    {
        public DateTimeBuilder() :
            base(DateTime.MinValue, DateTime.MaxValue)
        {
        }

        public override DateTime BuildItem()
        {
            var minTicks = Min.Ticks;
            var maxTicks = Max.Ticks;

            return new DateTime(
                (long) (minTicks + Data.Random.Value.NextDouble()*(maxTicks - minTicks))
                );
        }

        protected override ValueBuilderBase<DateTime, DateTime> CreateClone()
        {
            return new DateTimeBuilder();
        }
    }
}