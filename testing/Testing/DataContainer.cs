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
            Byte = new ByteBuilder();
            Short = new ShortBuilder();
            Integer = new IntegerBuilder();
            DateTime = new DateTimeBuilder();
            Text = new TextBuilder(Resources.Chars);
        }

        #region IDataContainer Members

        public IDataResources Resources
        {
            get { return _resources; }
        }

        public BooleanBuilder Boolean { get; set; }

        public ByteBuilder Byte { get; set; }
        public ShortBuilder Short { get; set; }
        public IntegerBuilder Integer { get; set; }
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