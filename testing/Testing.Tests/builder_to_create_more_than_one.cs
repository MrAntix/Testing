using System.Linq;
using Moq;
using Testing.Tests.Pocis;
using Xunit;

namespace Testing.Tests
{
    public class builder_to_create_more_than_one
    {
        readonly Builder<IThingy> _builder;

        public builder_to_create_more_than_one()
        {
            _builder = new Builder<IThingy>(Mock.Of<IThingy>);
        }

        [Fact]
        public void creates_two_with_two_calls_to_build()
        {
            var firstOne = _builder.BuildItem();
            var secondOne = _builder.BuildItem();

            Assert.NotNull(firstOne);
            Assert.NotNull(secondOne);

            Assert.NotSame(firstOne, secondOne);
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_a_count()
        {
            const int expectedCount = 10;
            var items = _builder
                .Build(expectedCount)
                .Items.ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount, items.Count());
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_a_count_uses_index()
        {
            const int expectedCount = 10;
            var items = _builder
                .Build(expectedCount, (x, i) => x.Count = i)
                .Items.ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount, items.Count());

            for (var i = 0; i < expectedCount; i++)
                Assert.Equal(i, items.ElementAt(i).Count);
        }

        [Fact]
        public void creates_a_group_with_two_calls_to_build_index_carries_on()
        {
            const int expectedCount = 10;
            var items = _builder
                .Build(expectedCount, (x, i) => x.Count = i)
                .Build(expectedCount, (x, i) => x.Count = i)
                .Items.ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount*2, items.Count());

            for (var i = 0; i < expectedCount*2; i++)
                Assert.Equal(i, items.ElementAt(i).Count);
        }

        [Fact]
        public void creates_a_group_with_two_calls_to_build_with_overridden_assign_on_second_call()
        {
            const int expectedCount = 10;
            const string secondCallName = "Second Call Name";
            var items = _builder
                .Build(expectedCount)
                .Build(expectedCount, (x, i) => x.Name = secondCallName)
                .Items.ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount*2, items.Count());

            Assert.Equal(expectedCount, items.Count(x => x.Name == secondCallName));
        }
    }
}