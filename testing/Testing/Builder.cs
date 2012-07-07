using Testing.Base;

namespace Testing
{
    public class Builder<T>
        : BuilderBase<T, Builder<T>>
    {
        protected override Builder<T> CreateClone()
        {
            return new Builder<T>();
        }
    }
}