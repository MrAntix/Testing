using System;
using System.Linq;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_text
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void get_array_of_text()
        {
            const int minLength = 5;
            const int maxLength = 10;
            const int minCount = 10;
            const int maxCount = 20;

            var items = DataContainer.Text
                .With(minLength, maxLength)
                .Build(minCount, maxCount)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<string[]>(items);
            Assert.InRange(items.Count(), minCount, maxCount);
        }

        [Fact]
        public void get_array_of_numbers_and_letters()
        {
            const int minLength = 5;
            const int maxLength = 10;
            const int count = 10;

            var numbersAndLetters
                = DataContainer.Resources.Letters
                    .Union(Data.Container.Resources.Numbers)
                    .ToArray();

            var items = DataContainer.Text
                .With(minLength, maxLength, numbersAndLetters)
                .Build(count)
                .Items.ToArray();

            foreach (var item in items) Console.WriteLine(item);

            Assert.IsType<string[]>(items);
            Assert.Equal(count, items.Count());
            Assert.True(items.SelectMany(i => i.ToCharArray()).All(numbersAndLetters.Contains));
        }
    }
}