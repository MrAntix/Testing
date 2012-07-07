using Testing.Builders;

namespace Testing
{
    public class DataContainer :
        IDataContainer
    {
        EmailBuilder _email;
        IntegerBuilder _integer;
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

        public BooleanBuilder Boolean { get; set; }
        public IntegerBuilder Integer { get; set; }
        public DoubleBuilder Double { get; set; }
        public DateTimeBuilder DateTime { get; set; }
        public TextBuilder Text { get; set; }

        public PersonBuilder Person
        {
            get
            {
                return _person
                       ?? (_person = new PersonBuilder(this));
            }
        }

        public EmailBuilder Email
        {
            get
            {
                return _email
                       ?? (_email = new EmailBuilder(this));
            }
        }

        public WebsiteBuilder Website
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