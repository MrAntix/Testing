using System.Linq;
using Xunit;

namespace Testing.Tests
{
    public class extensions_get_random_data
    {
        readonly string[] _names = new[] {"Abe", "Bob", "Charlie", "Derric"};

        [Fact]
        public void gets_one_of_the_items()
        {
            var item = _names.OneOf();

            Assert.NotNull(item);
            Assert.Contains(item, _names);
        }

        [Fact]
        public void gets_first_eventually()
        {
            var item = _names.First();
            var tries = 1000;
            while (tries > 0 &&
                   item != _names.OneOf())
            {
                tries--;
            }
            Assert.True(tries > 0);
        }

        [Fact]
        public void gets_last_eventually()
        {
            var item = _names.Last();
            var tries = 1000;
            while (tries > 0 &&
                   item != _names.OneOf())
            {
                tries--;
            }
            Assert.True(tries > 0);
        }

        [Fact]
        public void gets_many_of_the_items()
        {
            const int expectedCount = 3;
            var items = _names
                .ManyOf(expectedCount)
                .ToArray();

            Assert.NotNull(items);
            Assert.Equal(expectedCount, items.Count());
            foreach (var item in items)
                Assert.Contains(item, _names);
        }
    }
}