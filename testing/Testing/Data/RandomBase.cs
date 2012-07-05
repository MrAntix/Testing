namespace Testing.Data
{
    public abstract class RandomBase<T>
    {
        T _maxValue;
        T _minValue;

        protected RandomBase(
            T minValue, T maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public abstract T Get(T min, T max);

        public T Get(T max)
        {
            return Get(_minValue, max);
        }

        public T Get()
        {
            return Get(_minValue, _maxValue);
        }
    }
}