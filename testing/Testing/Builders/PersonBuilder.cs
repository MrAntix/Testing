using System;
using Testing.Data;
using Random = Testing.Data.Random;

namespace Testing.Builders
{
    public class PersonBuilder : Builder<TestData.Person>
    {
        public PersonBuilder()
        {
            With(p =>
                     {
                         p.Gender = TestData.Person.Genders.OneOf();
                         p.FirstName = p.Gender == TestData.Person.GenderTypes.Female
                                           ? TestData.Person.FirstNamesFemale.OneOf()
                                           : TestData.Person.FirstNamesMale.OneOf();
                         p.LastName = TestData.Person.LastNames.OneOf();

                         p.DateOfBirth = Random.DateTime.Get(
                             DateTime.Now.AddYears(-130),
                             DateTime.Now);

                         p.Emails = new EmailBuilder(p).Build(0, 3).Items;
                     });
        }
    }
}