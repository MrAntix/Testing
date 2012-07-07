using System.Collections.Generic;
using System.Linq;
using Testing.Base;

namespace Testing.Builders
{
    public class TextBuilder :
        ValueBuilderBase<string, int>
    {
        IEnumerable<char> _chars;

        public TextBuilder(IEnumerable<char> chars) :
            base(0, 250)
        {
            _chars = chars;
        }

        public TextBuilder With(int minLength, int maxLength, IEnumerable<char> chars)
        {
            var clone = (TextBuilder) Clone();
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

        protected override ValueBuilderBase<string, int> CreateClone()
        {
            return new TextBuilder(_chars);
        }
    }
}