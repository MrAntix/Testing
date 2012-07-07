using System.Linq;

namespace Testing.Base
{
    public abstract class ValueBuilderBase<T, TLimits> :
        BuilderBase<T>
    {
        protected TLimits Max;
        protected TLimits Min;

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

        public ValueBuilderBase<T, TLimits> With(TLimits max)
        {
            return With(Min, max);
        }

        public ValueBuilderBase<T, TLimits> With(TLimits min, TLimits max)
        {
            var clone = (ValueBuilderBase<T, TLimits>) Clone();
            clone.Min = min;
            clone.Max = max;

            return clone;
        }

        protected abstract ValueBuilderBase<T, TLimits> CreateClone();

        public override object Clone()
        {
            var instance = CreateClone();
            instance.Items = Items;
            instance.Min = Min;
            instance.Max = Max;

            return instance;
        }

        public ValueBuilderBase<T, TLimits> Build(int min, int max)
        {
            return Build(
                Data.Random.Value.Next(min, max)
                );
        }

        public ValueBuilderBase<T, TLimits> Build(int exactCount)
        {
            var items =
                Enumerable.Range(0, exactCount)
                    .Select(index => BuildItem());

            if (Items != null) items = Items.Concat(items);

            var clone = (ValueBuilderBase<T, TLimits>) Clone();
            clone.Items = items;

            return clone;
        }
    }
}