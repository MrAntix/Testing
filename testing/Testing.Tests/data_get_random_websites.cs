using System;
using System.Linq;
using Testing.Models;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_websites
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void get_array()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var items = DataContainer.Website
                .Build(minValue, maxValue)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<TestingWebsiteModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }
    }
}