using Antix.Testing.Abstraction.Builders;

namespace Antix.Testing.Abstraction
{
    public interface IDataContainer
    {
        IDataResources Resources { get; }

        IBooleanBuilder Boolean { get; }
        IIntegerBuilder Integer { get; }
        IDoubleBuilder Double { get; }
        IDateTimeBuilder DateTime { get; }
        ITextBuilder Text { get; }

        IPersonBuilder Person { get; }
        IEmailBuilder Email { get; }
        IWebsiteBuilder Website { get; }
    }
}