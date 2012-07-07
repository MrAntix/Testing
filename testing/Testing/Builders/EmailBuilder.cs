using Testing.Base;
using Testing.Models;

namespace Testing.Builders
{
    public class EmailBuilder : BuilderBase<TestingEmailModel, EmailBuilder>
    {
        readonly IDataContainer _dataContainer;
        TestingPersonModel _person;

        public EmailBuilder(IDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            Assign = email =>
                         {
                             email.Type = _dataContainer.Resources.EmailTypes.OneOf();
                             email.Address = string.Format("{0}.{1}@{2}",
                                                           _person.FirstName.Trim().ToLower(),
                                                           _person.LastName.Trim().ToLower(),
                                                           _dataContainer.Resources.WebDomains.OneOf());
                         };
        }

        public EmailBuilder With(TestingPersonModel person)
        {
            _person = person;

            return this;
        }

        protected override EmailBuilder CreateClone()
        {
            return new EmailBuilder(_dataContainer);
        }
    }
}