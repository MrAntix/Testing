using System;
using System.Linq;
using Antix.Testing.Abstraction;
using Antix.Testing.Models;
using Xunit;

namespace Antix.Testing.Tests
{
    public class data_get_random_people
    {
        protected IDataContainer DataContainer
            = new DataContainer(new DataResources());

        [Fact]
        public void get_array()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var items = DataContainer.Person
                                     .Build(minValue, maxValue)
                                     .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<PersonModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }

        [Fact]
        public void get_array_gender_and_age_range()
        {
            const int minValue = 10;
            const int maxValue = 20;
            const int minAge = 30;
            const int maxAge = 40;

            var items = DataContainer.Person
                                     .WithGender(GenderTypes.Female)
                                     .WithAge(minAge, maxAge)
                                     .Build(minValue, maxValue)
                                     .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<PersonModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
            Assert.True(items.All(p => p.Gender == GenderTypes.Female));
            Assert.True(items.All(p => p.Age >= minAge && p.Age <= maxAge));
        }

        [Fact]
        public void get_array_gender()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var items = DataContainer.Person
                                     .WithGender(GenderTypes.Male)
                                     .Build(minValue, maxValue)
                                     .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<PersonModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
            Assert.True(items.All(p => p.Gender == GenderTypes.Male));
        }

        [Fact]
        public void get_array_first_names()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var items = DataContainer.Resources.PersonFirstNamesMale
                                     .ManyOf(minValue, maxValue)
                                     .ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<string[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }
    }
}