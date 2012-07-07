using Testing.Builders;

namespace Testing
{
    public interface IDataContainer
    {
        IDataResources Resources { get; }

        BooleanBuilder Boolean { get; }
        IntegerBuilder Integer { get; }
        DoubleBuilder Double { get; }
        DateTimeBuilder DateTime { get; }
        TextBuilder Text { get; }

        PersonBuilder Person { get; }
        EmailBuilder Email { get; }
        WebsiteBuilder Website { get; }
    }
}