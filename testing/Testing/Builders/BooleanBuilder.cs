using Testing.Base;

namespace Testing.Builders
{
    public class BooleanBuilder :
        ValueBuilderBase<IBooleanBuilder, bool, bool>,
        IBooleanBuilder
    {
        #region IBooleanBuilder Members

        public override bool BuildItem()
        {
            return Data.Random.Value.Next(2) == 1;
        }

        #endregion

        protected override IBooleanBuilder CreateClone()
        {
            return new BooleanBuilder();
        }
    }
}