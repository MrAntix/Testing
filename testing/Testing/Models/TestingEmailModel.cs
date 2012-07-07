namespace Testing.Models
{
    public class TestingEmailModel
    {
        public string Type { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("TestingEmailModel: {0} ({1})", Address, Type).Trim();
        }
    }
}