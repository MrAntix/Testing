using Testing.Base;

namespace Testing.Builders
{
    public class BooleanBuilder :
        ValueBuilderBase<bool, bool>
    {
        public override bool BuildItem()
        {
            return Data.Random.Value.Next(2) == 1;
        }

        protected override ValueBuilderBase<bool, bool> CreateClone()
        {
            return new BooleanBuilder();
        }
    }
}