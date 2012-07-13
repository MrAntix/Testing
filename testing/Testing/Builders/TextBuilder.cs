using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Testing.Abstraction.Base;
using Testing.Abstraction.Builders;

namespace Testing.Builders
{
    public class TextBuilder :
        ValueBuilderBase<ITextBuilder, string, int>,
        ITextBuilder
    {
        IEnumerable<char> _chars;

        public TextBuilder(IEnumerable<char> chars) :
            base(0, 250)
        {
            _chars = chars;
        }

        public ITextBuilder WithCharacters(IEnumerable<char> chars)
        {
            var clone = Clone() as TextBuilder;
            Debug.Assert(clone != null, "clone != null");

            clone._chars = chars;

            return clone;
        }

        public override string BuildItem()
        {
            return new string(
                _chars.ManyOf(Min, Max).ToArray());
        }

        protected override ITextBuilder CreateClone()
        {
            return new TextBuilder(_chars);
        }
    }
}