using Moq;
using Testing.Builders;
using Testing.Tests.Pocis;

namespace Testing.Tests
{
    public class builder_to_create_pocis_using_moq :
        builder_to_create<IThingy>
    {
        public builder_to_create_pocis_using_moq() :
            base(new Builder<IThingy>().Create(Mock.Of<IThingy>))
        {
        }
    }
}