using System;
using System.Linq;
using Testing.Abstraction;
using Testing.Builders;
using Testing.Tests.Pocos;
using Xunit;

namespace Testing.Tests
{
    public class data_using_default_person_builder
    {
        readonly Builder<MyPerson> _builder;
        readonly EmailBuilder _emailBuilder;
        readonly PersonBuilder _personBuilder;

        protected IDataContainer DataContainer = new DataContainer(new DataResources());

        public data_using_default_person_builder()
        {
            _personBuilder = new PersonBuilder(DataContainer);
            _emailBuilder = new EmailBuilder(DataContainer);

            _builder = new Builder<MyPerson>()
                .With(x =>
                          {
                              var person = _personBuilder.BuildItem();
                              var emails = _emailBuilder.WithPerson(person).Build(1, 3).Items;

                              x.Name = person.FullName;
                              x.Emails = emails.Select(e => e.Address);
                          });
        }

        [Fact]
        public void can_create_person()
        {
            var person = _builder.BuildItem();

            Assert.NotNull(person);
            Assert.NotNull(person.Name);
            Assert.NotNull(person.Emails);
        }

        [Fact]
        public void can_create_people()
        {
            foreach (var person in _builder.Build(1000).Items)
            {
                Console.WriteLine(person);

                Assert.NotNull(person);
                Assert.NotNull(person.Name);
                Assert.NotNull(person.Emails);
            }
        }
    }
}