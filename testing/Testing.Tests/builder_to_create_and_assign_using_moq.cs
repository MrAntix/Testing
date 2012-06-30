using System.Linq;
using Moq;
using Testing.Builders;
using Testing.Tests.Data;
using Testing.Tests.Pocis;
using Xunit;

namespace Testing.Tests
{
    public class builder_to_create_and_assign_using_moq
    {
        readonly Builder<IThingy> _builder;

        readonly string _expectedName = TestData.Person.Names.First();

        public builder_to_create_and_assign_using_moq()
        {
            _expectedName = TestData.Person.Names.First();
            _builder = new Builder<IThingy>()
                .Create(Mock.Of<IThingy>)
                .With(x => x.Name = _expectedName);
        }

        [Fact]
        public void can_assign_values()
        {
            var item = _builder.Build();
            Assert.Equal(_expectedName, item.Name);
        }

        [Fact]
        public void can_override_assigned_values()
        {
            var overridenName = TestData.Person.Names.ElementAt(1);

            var item = _builder.Build(x => x.Name = overridenName);
            Assert.Equal(overridenName, item.Name);
        }
    }
}