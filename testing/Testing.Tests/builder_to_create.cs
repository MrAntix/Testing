using Testing.Abstraction;
using Xunit;

namespace Testing.Tests
{
    public abstract class builder_to_create<T>
    {
        readonly Builder<T> _builder;
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        protected builder_to_create(
            Builder<T> builder)
        {
            _builder = builder;
        }

        [Fact]
        public void creates_instance()
        {
            var item = _builder.Build();

            Assert.NotNull(item);
        }
    }
}