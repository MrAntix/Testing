using Testing.Abstraction;
using Testing.Abstraction.Builders;
using Testing.Builders;

namespace Testing
{
    public class DataContainer :
        IDataContainer
    {
        EmailBuilder _email;
        PersonBuilder _person;
        IDataResources _resources;

        WebsiteBuilder _website;

        public DataContainer(IDataResources resources)
        {
            _resources = resources;

            Boolean = new BooleanBuilder();
            Integer = new IntegerBuilder();
            Double = new DoubleBuilder();
            DateTime = new DateTimeBuilder();
            Text = new TextBuilder(Resources.Chars);
        }

        #region IDataContainer Members

        public IDataResources Resources
        {
            get { return _resources; }
        }

        public IBooleanBuilder Boolean { get; set; }
        public IIntegerBuilder Integer { get; set; }
        public IDoubleBuilder Double { get; set; }
        public IDateTimeBuilder DateTime { get; set; }
        public ITextBuilder Text { get; set; }

        public IPersonBuilder Person
        {
            get
            {
                return _person
                       ?? (_person = new PersonBuilder(this));
            }
        }

        public IEmailBuilder Email
        {
            get
            {
                return _email
                       ?? (_email = new EmailBuilder(this));
            }
        }

        public IWebsiteBuilder Website
        {
            get
            {
                return _website
                       ?? (_website = new WebsiteBuilder(this));
            }
        }

        #endregion
    }
}