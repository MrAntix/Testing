using System.Collections.Generic;

namespace Antix.Testing.Tests.Pocos
{
    public class MyPerson
    {
        public string Name { get; set; }
        public IEnumerable<string> Emails { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1}",
                Name,
                string.Join(", ", Emails)
                );
        }
    }
}