using System;
using System.Collections.Generic;

namespace Antix.Testing.Abstraction
{
    public interface IBuilder<out TBuilder, out T> :
        IEnumerable<T>, ICloneable
        where TBuilder : class, IBuilder<TBuilder, T>
    {
        TBuilder With(Action<T> assign);

        T Build();
        T Build(Action<T> assign);

        TBuilder Build(int minCount, int maxCount);
        TBuilder Build(int minCount, int maxCount, Action<T> assign);
        TBuilder Build(int minCount, int maxCount, Action<T, int> assign);

        TBuilder Build(int exactCount);
        TBuilder Build(int exactCount, Action<T> assign);
        TBuilder Build(int exactCount, Action<T, int> assign);

        int Index { get; }
        IBuilder<TBuilder, T> ResetIndex();
    }
}