using System;
using Antix.Testing.Abstraction.Base;
using Antix.Testing.Abstraction.Builders;

namespace Antix.Testing.Builders
{
    public class DateTimeBuilder :
        ValueBuilderBase<IDateTimeBuilder, DateTime, DateTime>,
        IDateTimeBuilder
    {
        public DateTimeBuilder() :
            base(DateTime.MinValue, DateTime.MaxValue)
        {
        }

        public override DateTime Build()
        {
            var minTicks = Min.Ticks;
            var maxTicks = Max.Ticks;

            return new DateTime(
                (long) (minTicks + TestData.Random.Value.NextDouble()*(maxTicks - minTicks))
                );
        }

        protected override IDateTimeBuilder CreateClone()
        {
            return new DateTimeBuilder();
        }
    }
}