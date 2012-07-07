using Testing.Base;

namespace Testing.Builders
{
    public class ShortBuilder :
        ValueBuilderBase<short, short>
    {
        public ShortBuilder() :
            base(0, short.MaxValue)
        {
        }

        public override short BuildItem()
        {
            return (short) Data.Random.Value.Next(Min, Max);
        }

        protected override ValueBuilderBase<short, short> CreateClone()
        {
            return new ShortBuilder();
        }
    }
}