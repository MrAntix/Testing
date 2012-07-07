using System;
using System.Linq;
using Testing.Models;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_data
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void get_a_random_number()
        {
            var minValue = 10;
            var maxValue = 20;

            var item = DataContainer.Integer
                .With(minValue, maxValue)
                .BuildItem();

            Console.WriteLine(item);

            Assert.IsType<int>(item);
            Assert.InRange(item, minValue, maxValue);
        }

        [Fact]
        public void get_an_array_of_random_numbers()
        {
            var minValue = 10;
            var maxValue = 20;

            var items = DataContainer.Integer
                .With(minValue, maxValue)
                .Build(2, 4)
                .Build(1, 6)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<int[]>(items);
            Assert.InRange(items.Count(), 3, 10);
        }

        [Fact]
        public void get_an_array_of_random_people()
        {
            var minValue = 10;
            var maxValue = 20;

            var items = DataContainer.Person
                .Build(minValue, maxValue)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<TestingPersonModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }

        [Fact]
        public void get_an_array_of_random_female_people_age_21_to_30()
        {
            var minValue = 10;
            var maxValue = 50;

            var items = DataContainer.Person
                .WithGender(TestingGenderTypes.Female)
                .WithAge(21, 30)
                .Build(minValue, maxValue)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<TestingPersonModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
            Assert.True(items.All(p => p.Gender == TestingGenderTypes.Female));
            Assert.True(items.All(p => p.Age >= 21 && p.Age <= 30));
        }

        [Fact]
        public void get_an_array_of_random_male_people()
        {
            var minValue = 10;
            var maxValue = 20;

            var items = DataContainer.Person
                .WithGender(TestingGenderTypes.Male)
                .Build(minValue, maxValue)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<TestingPersonModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
            Assert.True(items.All(p => p.Gender == TestingGenderTypes.Male));
        }

        [Fact]
        public void get_an_array_of_random_websites()
        {
            var minValue = 10;
            var maxValue = 20;

            var items = DataContainer.Website
                .Build(minValue, maxValue)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<TestingWebsiteModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }

        [Fact]
        public void get_an_array_of_random_person_first_names()
        {
            var minValue = 10;
            var maxValue = 20;

            var items = DataContainer.Resources.PersonFirstNamesMale
                .ManyOf(minValue, maxValue)
                .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<string[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }

        [Fact]
        public void get_an_array_of_random_text()
        {
            var minLength = 5;
            var maxLength = 10;
            var minCount = 10;
            var maxCount = 20;

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
        public void get_an_array_of_random_numbers_and_letters()
        {
            var minLength = 5;
            var maxLength = 10;
            var minCount = 10;
            var maxCount = 20;

            var numbersAndLetters
                = DataContainer.Resources.Letters
                    .Union(Data.Container.Resources.Numbers)
                    .ToArray();

            var items = DataContainer.Text
                .With(minLength, maxLength, numbersAndLetters)
                .Build(minCount, maxCount)
                .Items.ToArray();

            foreach (var item in items) Console.WriteLine(item);

            Assert.IsType<string[]>(items);
            Assert.InRange(items.Count(), minCount, maxCount);
            Assert.True(items.SelectMany(i => i.ToCharArray()).All(numbersAndLetters.Contains));
        }
    }
}