using Antix.Testing.Models;

namespace Antix.Testing.Abstraction.Builders
{
    public interface IEmailBuilder :
        IBuilder<IEmailBuilder, EmailModel>
    {
        IEmailBuilder WithPerson(PersonModel person);
    }
}