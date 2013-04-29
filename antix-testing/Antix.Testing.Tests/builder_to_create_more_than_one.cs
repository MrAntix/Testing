using System;
using System.Linq;
using Antix.Testing.Tests.Pocis;
using Moq;
using Xunit;

namespace Antix.Testing.Tests
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
            var firstOne = _builder.Build();
            var secondOne = _builder.Build();

            Assert.NotNull(firstOne);
            Assert.NotNull(secondOne);

            Assert.NotSame(firstOne, secondOne);
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_a_range()
        {
            const int minCount = 5;
            const int maxCount = 10;

            var items = _builder
                .Build(minCount, maxCount)
                .ToArray();

            Assert.NotNull(items);
            Assert.InRange(items.Count(), minCount, maxCount);
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_a_range_and_assign()
        {
            const int minCount = 5;
            const int maxCount = 10;
            const string expectedName = "name";

            var items = _builder
                .Build(minCount, maxCount, x => x.Name = expectedName)
                .ToArray();

            Assert.NotNull(items);
            Assert.InRange(items.Count(), minCount, maxCount);

            Assert.True(items.All(x => x.Name == expectedName));
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_a_range_and_assign_with_index()
        {
            const int minCount = 5;
            const int maxCount = 10;

            var items = _builder
                .Build(minCount, maxCount, (x, i) => x.Count = i)
                .ToArray();

            Assert.NotNull(items);
            Assert.InRange(items.Count(), minCount, maxCount);

            for (var i = 0; i < items.Count(); i++)
                Assert.Equal(i, items.ElementAt(i).Count);
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_an_exact_count()
        {
            const int expectedCount = 10;

            var items = _builder
                .Build(expectedCount)
                .ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount, items.Count());
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_an_exact_count_and_assign()
        {
            const int expectedCount = 10;
            const string expectedName = "name";

            var items = _builder
                .Build(expectedCount, x => x.Name = expectedName)
                .ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount, items.Count());

            Assert.True(items.All(x => x.Name == expectedName));
        }

        [Fact]
        public void creates_a_group_with_call_to_build_with_an_exact_count_uses_index()
        {
            const int expectedCount = 10;
            var items = _builder
                .Build(expectedCount, (x, i) => x.Count = i)
                .ToArray();

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
                .ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount * 2, items.Count());

            for (var i = 0; i < expectedCount * 2; i++)
                Assert.Equal(i, items.ElementAt(i).Count);
        }

        [Fact]
        public void creates_a_group_with_two_calls_to_build_index_reset()
        {
            const int expectedCount = 10;
            var items = _builder
                .Build(expectedCount, (x, i) => x.Count = i)
                .ResetIndex()
                .Build(expectedCount, (x, i) => x.Count = i)
                .ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount * 2, items.Count());

            for (var i = 0; i < expectedCount; i++)
                Assert.Equal(i, items.ElementAt(i).Count);

            for (var i = 0; i < expectedCount; i++)
                Assert.Equal(i, items.ElementAt(i + expectedCount).Count);
        }

        [Fact]
        public void creates_a_group_with_two_calls_to_build_with_overridden_assign_on_second_call()
        {
            const int expectedCount = 10;
            const string secondCallName = "Second Call Name";
            var items = _builder
                .Build(expectedCount)
                .Build(expectedCount, (x, i) => x.Name = secondCallName)
                .ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount*2, items.Count());

            Assert.Equal(expectedCount, items.Count(x => x.Name == secondCallName));
        }

        [Fact]
        public void creates_new_groups_each_call()
        {
            const int expectedCount = 10;
            var builder = _builder
                .Build(expectedCount, (x, i) =>
                                          {
                                              x.Name = TestData.Text.WithLetters().WithRange(2, 10).Build();
                                              x.Count = i;
                                          });

            var group1 = builder.ToArray();
            var group2 = builder.ToArray();
            for (var i = 0; i < group1.Length; i++)
                Console.WriteLine(
                    "{0} - {1}", group1.ElementAt(i).Name, group2.ElementAt(i).Name);

            Assert.NotEqual(
                expectedCount,
                group1
                    .Where((x, i) => x.Name == group2.ElementAt(i).Name)
                    .Count());
        }
    }
}