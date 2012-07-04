using System;
using System.Linq;
using Testing.Builders;
using Testing.Tests.Pocos;
using Xunit;

namespace Testing.Tests
{
    public class data_using_default_person_builder
    {
        readonly Builder<MyPerson> _builder;
        readonly PersonBuilder _personBuilder;

        public data_using_default_person_builder()
        {
            _personBuilder = new PersonBuilder();

            _builder = new Builder<MyPerson>()
                .With(x =>
                          {
                              var person = _personBuilder.Build();

                              x.Name = person.FullName;
                              x.Emails = person.Emails.Select(e => e.Address);
                          });
        }

        [Fact]
        public void can_create_person()
        {
            var person = _builder.Build();

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