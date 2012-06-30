using Testing.Builders;
using Testing.Tests.Pocos;

namespace Testing.Tests
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