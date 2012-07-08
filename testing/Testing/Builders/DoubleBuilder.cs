using Testing.Base;

namespace Testing.Builders
{
    public class DoubleBuilder :
        ValueBuilderBase<DoubleBuilder, double, double>
    {
        public DoubleBuilder() :
            base(0, double.MaxValue)
        {
        }

        public override double BuildItem()
        {
            return ((Data.Random.Value.NextDouble()*(Max - Min)) + Min);
        }

        protected override DoubleBuilder CreateClone()
        {
            return new DoubleBuilder();
        }
    }
}