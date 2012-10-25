using Xunit;

namespace Antix.Testing.Tests
{
    public abstract class builder_to_create<T>
    {
        readonly Builder<T> _builder;

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