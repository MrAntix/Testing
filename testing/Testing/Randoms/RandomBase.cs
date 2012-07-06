namespace Testing.Randoms
{
    public abstract class RandomBase<T, TLimits>
    {
        TLimits _maxValue;
        TLimits _minValue;

        protected RandomBase(
            TLimits minValue, TLimits maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public abstract T Get(TLimits min, TLimits max);

        public T Get(TLimits max)
        {
            return Get(_minValue, max);
        }

        public T Get()
        {
            return Get(_minValue, _maxValue);
        }
    }
}