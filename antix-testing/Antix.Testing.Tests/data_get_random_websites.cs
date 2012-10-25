using System;
using System.Linq;
using Antix.Testing.Abstraction;
using Antix.Testing.Models;
using Xunit;

namespace Antix.Testing.Tests
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
                                     .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<WebsiteModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }
    }
}