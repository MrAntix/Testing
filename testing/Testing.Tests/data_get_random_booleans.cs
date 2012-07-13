using System.Linq;
using Testing.Abstraction;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_booleans
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void get_array()
        {
            const int count = 100;

            var items = DataContainer.Boolean
                .Build(count)
                .Items.ToArray();

            Assert.Equal(count, items.Count());
            Assert.IsType<bool[]>(items);
            Assert.True(items.Any(i => i));
            Assert.True(items.Any(i => !i));
        }
    }
}