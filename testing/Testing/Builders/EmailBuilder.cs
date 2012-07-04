using Testing.Data;

namespace Testing.Builders
{
    public class EmailBuilder : Builder<TestData.Email>
    {
        TestData.Person _person;

        public EmailBuilder(TestData.Person person)
        {
            _person = person;
            With(email =>
                     {
                         email.Type = TestData.Email.Types.OneOf();
                         email.Address = string.Format("{0}.{1}@{2}",
                                                       _person.FirstName.Trim().ToLower(),
                                                       _person.LastName.Trim().ToLower(),
                                                       TestData.Web.Domains.OneOf());
                     });
        }
    }
}