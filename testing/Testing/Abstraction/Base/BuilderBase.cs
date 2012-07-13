using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Testing.Abstraction.Base
{
    public abstract class BuilderBase<TBuilder, T> :
        IBuilder<TBuilder, T>
        where TBuilder : class, IBuilder<TBuilder, T>
    {
        protected Action<T> Assign;
        protected int Index;
        Func<T> _create = Activator.CreateInstance<T>;

        public IEnumerable<T> Items { get; set; }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        public TBuilder Clone()
        {
            return ClonePrivate() as TBuilder;
        }

        BuilderBase<TBuilder, T> ClonePrivate()
        {
            var clone = CreateClone()
                        as BuilderBase<TBuilder, T>;
            Debug.Assert(clone != null, "clone != null");

            clone.Assign = Assign;
            clone._create = _create;
            clone.Index = Index;
            clone.Items = Items;

            return clone;
        }

        protected abstract TBuilder CreateClone();


        public TBuilder Create(
            Func<T> create = null)
        {
            _create = create;

            return this as TBuilder;
        }

        public TBuilder With(
            Action<T> assign)
        {
            if (assign == null) throw new ArgumentNullException("assign");

            var clone = ClonePrivate();
            clone.Assign = Assign == null
                               ? assign
                               : x =>
                                     {
                                         Assign(x);
                                         assign(x);
                                     };

            return clone as TBuilder;
        }

        public T BuildItem()
        {
            var item = _create();
            if (Assign != null) Assign(item);

            return item;
        }

        public TBuilder Build(
            int minCount, int maxCount)
        {
            return Build(minCount, maxCount, null);
        }

        public TBuilder Build(
            int minCount, int maxCount,
            Action<T, int> assign)
        {
            return Build(Data.Random.Value.Next(minCount, maxCount), assign);
        }

        public TBuilder Build(
            int exactCount)
        {
            return Build(exactCount, null);
        }

        public TBuilder Build(
            int exactCount,
            Action<T, int> assign)
        {
            var items =
                Enumerable.Range(0, exactCount)
                    .Select(index =>
                                {
                                    var item = BuildItem();
                                    if (assign != null) assign(item, Index + index);

                                    return item;
                                });

            if (Items != null) items = Items.Concat(items);

            var clone = ClonePrivate();
            clone.Index = exactCount;
            clone.Items = items;

            return clone as TBuilder;
        }
    }
}