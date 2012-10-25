using System;
using Antix.Testing.Abstraction.Base;

namespace Antix.Testing
{
    public class Builder<T>
        : BuilderBase<Builder<T>, T>
    {
        public Builder()
        {
        }

        public Builder(Func<T> create) : base(create)
        {
        }

        protected override Builder<T> CreateClone()
        {
            return new Builder<T>();
        }
    }
}