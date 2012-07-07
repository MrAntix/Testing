using System;

namespace Testing.Models
{
    public class TestingPersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TestingGenderTypes Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - DateOfBirth.Year;
                return DateOfBirth.AddYears(age) > DateTime.Today
                           ? --age
                           : age;
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName).Trim(); }
        }

        public override string ToString()
        {
            return string.Format("TestingPersonModel: {0} {1}, {2}, age: {3}", FirstName, LastName, Gender, Age).Trim();
        }
    }
}