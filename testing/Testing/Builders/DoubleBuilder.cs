using Testing.Base;

namespace Testing.Builders
{
    public class DoubleBuilder :
        ValueBuilderBase<double, double>
    {
        public DoubleBuilder() :
            base(0, double.MaxValue)
        {
        }

        public override double BuildItem()
        {
            return ((Data.Random.Value.NextDouble()*(Max - Min)) + Min);
        }

        protected override ValueBuilderBase<double, double> CreateClone()
        {
            return new DoubleBuilder();
        }
    }
}