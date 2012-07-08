using System.Collections.Generic;

namespace Testing
{
    public interface IValueBuilder<TBuilder, T, TLimits>
        where TBuilder : class, IValueBuilder<TBuilder, T, TLimits>
    {
        TLimits Min { get; }
        TLimits Max { get; }
        IEnumerable<T> Items { get; }

        TBuilder With(TLimits max);
        TBuilder With(TLimits min, TLimits max);
        T BuildItem();
        TBuilder Build(int min, int max);
        TBuilder Build(int exactCount);
    }
}