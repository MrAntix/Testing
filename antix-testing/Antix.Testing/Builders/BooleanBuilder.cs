using Antix.Testing.Abstraction.Base;
using Antix.Testing.Abstraction.Builders;

namespace Antix.Testing.Builders
{
    public class BooleanBuilder :
        ValueBuilderBase<IBooleanBuilder, bool, bool>,
        IBooleanBuilder
    {
        #region IBooleanBuilder Members

        public override bool Build()
        {
            return TestData.Random.Value.Next(2) == 1;
        }

        #endregion

        protected override IBooleanBuilder CreateClone()
        {
            return new BooleanBuilder();
        }
    }
}