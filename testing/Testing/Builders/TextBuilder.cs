using System.Collections.Generic;
using System.Linq;
using Testing.Base;

namespace Testing.Builders
{
    public class TextBuilder :
        ValueBuilderBase<TextBuilder, string, int>
    {
        IEnumerable<char> _chars;

        public TextBuilder(IEnumerable<char> chars) :
            base(0, 250)
        {
            _chars = chars;
        }

        public TextBuilder With(int minLength, int maxLength, IEnumerable<char> chars)
        {
            var clone = Clone();
            clone.Min = minLength;
            clone.Max = maxLength;
            clone._chars = chars;

            return clone;
        }

        public override string BuildItem()
        {
            return new string(
                _chars.ManyOf(Min, Max).ToArray());
        }

        protected override TextBuilder CreateClone()
        {
            return new TextBuilder(_chars);
        }
    }
}