using System;
using System.Collections.Generic;

namespace Testing.Abstraction
{
    public interface IBuilder<TBuilder, T> :
        ICloneable
        where TBuilder : class, IBuilder<TBuilder, T>
    {
        IEnumerable<T> Items { get; }

        TBuilder Create(Func<T> create = null);

        TBuilder With(Action<T> assign);
        T BuildItem();
        TBuilder Build(int minCount, int maxCount);
        TBuilder Build(int minCount, int maxCount, Action<T, int> assign);
        TBuilder Build(int exactCount);
        TBuilder Build(int exactCount, Action<T, int> assign);
    }
}