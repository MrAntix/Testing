using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IDataResources
    {
        IEnumerable<bool> Booleans { get; }

        IEnumerable<string> PersonFirstNamesMale { get; }
        IEnumerable<string> PersonFirstNamesFemale { get; }
        IEnumerable<TestingGenderTypes> DataGenders { get; }
        IEnumerable<string> PersonLastNames { get; }

        IEnumerable<string> WebDomains { get; }
        IEnumerable<string> EmailTypes { get; }

        IEnumerable<char> Chars { get; }
        IEnumerable<char> Letters { get; }
        IEnumerable<char> Numbers { get; }
    }
}