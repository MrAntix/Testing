using System.Linq;
using Antix.Testing.Tests.Pocis;
using Moq;
using Xunit;

namespace Antix.Testing.Tests
{
    public class builder_to_create_and_assign_using_moq
    {
        readonly Builder<IThingy> _builder;
        readonly string _expectedName;
        readonly string[] _names = new[] {"Abe", "Bob", "Charlie", "Derric"};

        public builder_to_create_and_assign_using_moq()
        {
            _expectedName = _names.First();
            _builder = new Builder<IThingy>(Mock.Of<IThingy>)
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
            var overridenName = _names.ElementAt(1);

            var item = _builder
                .Build(x => x.Name = overridenName);

            Assert.Equal(overridenName, item.Name);
        }
    }
}