using Testing.Abstraction.Base;
using Testing.Abstraction.Builders;

namespace Testing.Builders
{
    public class DoubleBuilder :
        ValueBuilderBase<IDoubleBuilder, double, double>,
        IDoubleBuilder
    {
        public DoubleBuilder() :
            base(0, double.MaxValue)
        {
        }

        public override double BuildItem()
        {
            return ((TestData.Random.Value.NextDouble()*(Max - Min)) + Min);
        }

        protected override IDoubleBuilder CreateClone()
        {
            return new DoubleBuilder();
        }
    }
}