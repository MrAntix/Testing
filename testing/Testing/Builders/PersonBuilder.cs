using System;

namespace Testing.Builders
{
    public class PersonBuilder : Builder<DataResources.Person>
    {
        public PersonBuilder()
        {
            With(p =>
                     {
                         p.Gender = DataResources.Person.Genders.OneOf();
                         p.FirstName = p.Gender == DataResources.Person.GenderTypes.Female
                                           ? DataResources.Person.FirstNamesFemale.OneOf()
                                           : DataResources.Person.FirstNamesMale.OneOf();
                         p.LastName = DataResources.Person.LastNames.OneOf();

                         p.DateOfBirth = Data.RandomDateTime.Get(
                             DateTime.Now.AddYears(-130),
                             DateTime.Now);

                         p.Emails = new EmailBuilder(p).Build(0, 3).Items;
                     });
        }
    }
}