using Antix.Testing.Tests.Pocis;
using Moq;

namespace Antix.Testing.Tests
{
    public class builder_to_create_pocis_using_moq :
        builder_to_create<IThingy>
    {
        public builder_to_create_pocis_using_moq() :
            base(new Builder<IThingy>(Mock.Of<IThingy>))
        {
        }
    }
}