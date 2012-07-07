using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing.Base
{
    public abstract class BuilderBase<T> :
        ICloneable
    {
        public IEnumerable<T> Items;

        #region ICloneable Members

        public abstract object Clone();

        #endregion

        public abstract T BuildItem();
    }

    public abstract class BuilderBase<T, TB> :
        BuilderBase<T>
        where TB : BuilderBase<T, TB>
    {
        protected Action<T> Assign;
        protected int Index;
        Func<T> _create = Activator.CreateInstance<T>;

        public override object Clone()
        {
            var clone = CreateClone();
            clone.Assign = Assign;
            clone._create = _create;
            clone.Index = Index;
            clone.Items = Items;

            return clone;
        }

        protected abstract TB CreateClone();

        public TB Create(
            Func<T> create = null)
        {
            _create = create;

            return this as TB;
        }

        public TB With(
            Action<T> assign)
        {
            if (assign == null) throw new ArgumentNullException("assign");

            var clone = (TB) Clone();
            clone.Assign = Assign == null
                               ? assign
                               : x =>
                                     {
                                         Assign(x);
                                         assign(x);
                                     };

            return clone;
        }

        public override T BuildItem()
        {
            var item = _create();
            if (Assign != null) Assign(item);

            return item;
        }

        public TB Build(
            int minCount, int maxCount)
        {
            return Build(Data.Random.Value.Next(minCount, maxCount));
        }

        public TB Build(
            int exactCount)
        {
            return Build(exactCount, null);
        }

        public TB Build(
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

            var clone = (TB) Clone();
            clone.Index = exactCount;
            clone.Items = items;

            return clone;
        }
    }
}