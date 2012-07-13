using System;
using System.Collections.Generic;

namespace Testing.Abstraction
{
    public interface IValueBuilder<TBuilder, T, TLimits> :
        ICloneable
        where TBuilder : class, IValueBuilder<TBuilder, T, TLimits>
    {
        TLimits Min { get; }
        TLimits Max { get; }
        IEnumerable<T> Items { get; }

        TBuilder WithMax(TLimits max);
        TBuilder WithRange(TLimits min, TLimits max);
        T BuildItem();
        TBuilder Build(int minCount, int maxCount);
        TBuilder Build(int exactCount);
    }
}