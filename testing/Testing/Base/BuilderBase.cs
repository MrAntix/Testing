using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing.Base
{
    public abstract class BuilderBase<TBuilder, T> :
        ICloneable
        where TBuilder : BuilderBase<TBuilder, T>
    {
        protected Action<T> Assign;
        protected int Index;
        public IEnumerable<T> Items;
        Func<T> _create = Activator.CreateInstance<T>;

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        public TBuilder Clone()
        {
            var clone = CreateClone();
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

            var clone = Clone();
            clone.Assign = Assign == null
                               ? assign
                               : x =>
                                     {
                                         Assign(x);
                                         assign(x);
                                     };

            return clone;
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
            return Build(Data.Random.Value.Next(minCount, maxCount));
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

            var clone = Clone();
            clone.Index = exactCount;
            clone.Items = items;

            return clone;
        }
    }
}