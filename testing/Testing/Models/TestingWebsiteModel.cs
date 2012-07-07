namespace Testing.Models
{
    public class TestingWebsiteModel
    {
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("TestingWebsiteModel: {0}", Address).Trim();
        }
    }
}