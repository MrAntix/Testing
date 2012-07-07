using Testing.Base;

namespace Testing.Builders
{
    public class IntegerBuilder :
        ValueBuilderBase<int, int>
    {
        public IntegerBuilder() :
            base( 0, int.MaxValue)
        {
        }

        public override int BuildItem()
        {
            return Data.Random.Value.Next(Min, Max);
        }

        protected override ValueBuilderBase<int, int> CreateClone()
        {
            return new IntegerBuilder();
        }
    }
}