using System.Linq;
using Testing.Abstraction;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_integers
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void get_array()
        {
            const int count = 100;

            var items = DataContainer.Integer
                .Build(count)
                .ToArray();

            Assert.Equal(count, items.Count());
            Assert.IsType<int[]>(items);
        }
    }
}