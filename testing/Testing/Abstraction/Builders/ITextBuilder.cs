using System.Collections.Generic;

namespace Testing.Abstraction.Builders
{
    public interface ITextBuilder :
        IValueBuilder<ITextBuilder, string, int>
    {
        ITextBuilder WithCharacters(IEnumerable<char> chars);
    }
}