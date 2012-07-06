namespace Testing.Builders
{
    public class EmailBuilder : Builder<DataResources.Email>
    {
        DataResources.Person _person;

        public EmailBuilder(DataResources.Person person)
        {
            _person = person;
            With(email =>
                     {
                         email.Type = DataResources.Email.Types.OneOf();
                         email.Address = string.Format("{0}.{1}@{2}",
                                                       _person.FirstName.Trim().ToLower(),
                                                       _person.LastName.Trim().ToLower(),
                                                       DataResources.Web.Domains.OneOf());
                     });
        }
    }
}