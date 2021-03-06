using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Antix.Testing.Abstraction;
using Antix.Testing.Abstraction.Base;
using Antix.Testing.Abstraction.Builders;

namespace Antix.Testing.Builders
{
    public class TextBuilder :
        ValueBuilderBase<ITextBuilder, string, int>,
        ITextBuilder
    {
        readonly IDataResources _resources;
        IEnumerable<char> _chars;

        public TextBuilder(IDataResources resources) :
            base(0, 250)
        {
            _resources = resources;
            _chars = resources.Chars;
        }

        public ITextBuilder WithNumbers()
        {
            return WithCharacters(_resources.Numbers);
        }

        public ITextBuilder WithLetters()
        {
            return WithCharacters(_resources.Letters);
        }

        public ITextBuilder WithNumbersAndLetters()
        {
            return WithCharacters(
                _resources.Numbers
                          .Concat(_resources.Letters)
                );
        }

        public ITextBuilder WithCharacters(IEnumerable<char> chars)
        {
            var clone = Clone() as TextBuilder;
            Debug.Assert(clone != null, "clone != null");

            clone._chars = chars;

            return clone;
        }

        public override string Build()
        {
            return new string(
                _chars.ManyOf(Min, Max).ToArray());
        }

        protected override ITextBuilder CreateClone()
        {
            return new TextBuilder(_resources) {_chars = _chars};
        }
    }
}