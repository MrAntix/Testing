using Antix.Testing.Tests.Pocos;

namespace Antix.Testing.Tests
{
    public class builder_to_create_pocos :
        builder_to_create<Thingy>
    {
        public builder_to_create_pocos() :
            base(new Builder<Thingy>())
        {
        }
    }
}