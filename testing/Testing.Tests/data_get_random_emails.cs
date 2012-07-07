using System;
using System.Linq;
using Testing.Models;
using Xunit;

namespace Testing.Tests
{
    public class data_get_random_emails
    {
        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        [Fact]
        public void requires_person_to_be_set()
        {
            Assert.Throws<InvalidOperationException>(
                () => DataContainer.Email
                          .BuildItem());
        }

        [Fact]
        public void get_array()
        {
            const int minValue = 10;
            const int maxValue = 20;

            var person = new TestingPersonModel
                             {
                                 FirstName = "Bob",
                                 LastName = "McNob"
                             };

            var items = DataContainer.Email
                .With(person)
                .Build(minValue, maxValue)
                .Items.ToArray();

            foreach (var item in items)
                Console.WriteLine(item);

            Assert.IsType<TestingEmailModel[]>(items);
            Assert.InRange(items.Count(), minValue, maxValue);
        }
    }
}