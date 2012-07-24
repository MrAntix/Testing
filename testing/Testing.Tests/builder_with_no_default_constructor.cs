using System;
using Testing.Abstraction.Base;
using Xunit;

namespace Testing.Tests
{
    public class builder_with_no_default_constructor
    {
        [Fact]
        void builderBase_clone_throws_exception()
        {
            var ex = Assert.Throws<MissingMethodException>(
                () => { var builder = new ABuilder("a").With(x => x.Prop = ""); });

            Console.WriteLine(ex.Message);
        }

        [Fact]
        void valueBuilderBase_clone_throws_exception()
        {
            var ex = Assert.Throws<MissingMethodException>(
                () => { var builder = new BBuilder("a").WithMax(1); });

            Console.WriteLine(ex.Message);
        }

        class A
        {
            public string Prop { get; set; }
        }

        class ABuilder : BuilderBase<ABuilder, A>
        {
            public ABuilder(string hi)
            {
            }
        }

        class BBuilder : ValueBuilderBase<BBuilder, object, object>
        {
            public BBuilder(string hi)
            {
            }

            public override object Build()
            {
                return null;
            }
        }
    }
}