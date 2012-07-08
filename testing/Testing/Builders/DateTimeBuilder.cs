using System;
using Testing.Base;

namespace Testing.Builders
{
    public interface IDateTimeBuilder
    {
    }

    public class DateTimeBuilder :
        ValueBuilderBase<DateTimeBuilder, DateTime, DateTime>,
        IDateTimeBuilder
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

        protected override DateTimeBuilder CreateClone()
        {
            return new DateTimeBuilder();
        }
    }
}