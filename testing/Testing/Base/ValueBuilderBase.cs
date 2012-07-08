using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Testing.Base
{
    public abstract class ValueBuilderBase<TBuilder, T, TLimits> :
        ICloneable, IValueBuilder<TBuilder, T, TLimits>
        where TBuilder : class, IValueBuilder<TBuilder, T, TLimits>
    {
        protected ValueBuilderBase()
        {
        }

        protected ValueBuilderBase(
            TLimits min,
            TLimits max)
        {
            Min = min;
            Max = max;
        }

        public IEnumerable<T> Items { get; set; }

        public TLimits Max { get; set; }
        public TLimits Min { get; set; }

        public TBuilder With(TLimits max)
        {
            return With(Min, max);
        }

        public TBuilder With(TLimits min, TLimits max)
        {
            var clone = CloneInternal();
            clone.Min = min;
            clone.Max = max;

            return clone as TBuilder;
        }

        public abstract T BuildItem();

        public TBuilder Build(int min, int max)
        {
            return Build(
                Data.Random.Value.Next(min, max)
                );
        }

        public TBuilder Build(int exactCount)
        {
            var items =
                Enumerable.Range(0, exactCount)
                    .Select(index => BuildItem());

            if (Items != null) items = Items.Concat(items);

            var clone = CloneInternal();
            clone.Items = items;

            return clone as TBuilder;
        }

        public TBuilder Clone()
        {
            return CloneInternal() as TBuilder;
        }

        ValueBuilderBase<TBuilder, T, TLimits> CloneInternal()
        {
            var clone = CreateClone()
                        as ValueBuilderBase<TBuilder, T, TLimits>;
            Debug.Assert(clone != null, "clone != null");

            clone.Items = Items;
            clone.Min = Min;
            clone.Max = Max;

            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        protected abstract TBuilder CreateClone();
    }
}