using Testing.Base;

namespace Testing
{
    public class Builder<T>
        : BuilderBase<Builder<T>, T>
    {
        protected override Builder<T> CreateClone()
        {
            return new Builder<T>();
        }
    }
}