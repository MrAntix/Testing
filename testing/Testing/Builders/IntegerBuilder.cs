using Testing.Base;

namespace Testing.Builders
{
    public class IntegerBuilder :
        ValueBuilderBase<IntegerBuilder, int, int>
    {
        public IntegerBuilder() :
            base(0, int.MaxValue)
        {
        }

        public override int BuildItem()
        {
            return Data.Random.Value.Next(Min, Max);
        }

        protected override IntegerBuilder CreateClone()
        {
            return new IntegerBuilder();
        }
    }
}