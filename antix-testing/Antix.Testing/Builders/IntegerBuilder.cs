using Antix.Testing.Abstraction.Base;
using Antix.Testing.Abstraction.Builders;

namespace Antix.Testing.Builders
{
    public class IntegerBuilder :
        ValueBuilderBase<IIntegerBuilder, int, int>,
        IIntegerBuilder
    {
        public IntegerBuilder() :
            base(0, int.MaxValue)
        {
        }

        public override int Build()
        {
            return TestData.Random.Value.Next(Min, Max);
        }

        protected override IIntegerBuilder CreateClone()
        {
            return new IntegerBuilder();
        }
    }
}