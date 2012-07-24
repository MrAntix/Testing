using System;
using System.Linq;
using Testing.Abstraction;
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
                .WithRange(minLength, maxLength)
                .Build(minCount, maxCount)
                .ToArray();

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
                    .Union(TestData.Resources.Numbers)
                    .ToArray();

            var items = DataContainer.Text
                .WithRange(minLength, maxLength)
                .WithCharacters(numbersAndLetters)
                .Build(count)
                .ToArray();

            foreach (var item in items) Console.WriteLine(item);

            Assert.IsType<string[]>(items);
            Assert.Equal(count, items.Count());
            Assert.True(items.SelectMany(i => i.ToCharArray()).All(numbersAndLetters.Contains));
        }
    }
}