using System;
using System.Linq;
using Testing.Abstraction;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_doubles
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void double_builder_get_a_random_double()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var item = DataContainer.Double
                .WithRange(minValue, maxValue)
                .BuildItem();

            Console.WriteLine(item);

            Assert.InRange(item, minValue, maxValue);
        }

        [Fact]
        public void double_builder_get_an_array_of_random_doubles()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var items = DataContainer.Double
                .WithRange(minValue, maxValue)
                .Build(2, 40)
                .Build(1, 60)
                .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.InRange(items.Count(), 3, 100);
            foreach (var item in items)
                Assert.InRange(item, minValue, maxValue);
        }
    }
}