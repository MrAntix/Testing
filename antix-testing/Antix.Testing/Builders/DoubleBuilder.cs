using Antix.Testing.Abstraction.Base;
using Antix.Testing.Abstraction.Builders;

namespace Antix.Testing.Builders
{
    public class DoubleBuilder :
        ValueBuilderBase<IDoubleBuilder, double, double>,
        IDoubleBuilder
    {
        public DoubleBuilder() :
            base(0, double.MaxValue)
        {
        }

        public override double Build()
        {
            return ((TestData.Random.Value.NextDouble()*(Max - Min)) + Min);
        }

        protected override IDoubleBuilder CreateClone()
        {
            return new DoubleBuilder();
        }
    }
}