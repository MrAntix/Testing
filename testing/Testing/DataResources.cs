using System;
using System.Collections.Generic;
using System.Linq;
using Testing.Models;
using Testing.Resources;

namespace Testing
{
    public class DataResources : IDataResources
    {
        IEnumerable<bool> _booleans = new[] {true, false};

        IEnumerable<char> _chars;
        IEnumerable<TestingGenderTypes> _dataGenders;
        IEnumerable<string> _emailTypes;
        IEnumerable<char> _letters;
        IEnumerable<char> _numbers;

        IEnumerable<string> _personFirstNamesFemale;
        IEnumerable<string> _personFirstNamesMale;
        IEnumerable<string> _personLastNames;

        IEnumerable<string> _webDomains;

        #region IDataResources Members

        public IEnumerable<bool> Booleans
        {
            get { return _booleans; }
        }

        public IEnumerable<char> Chars
        {
            get
            {
                return _chars ?? (
                                     _chars = TextResources.Chars.ToCharArray()
                                 );
            }
        }

        public IEnumerable<char> Letters
        {
            get
            {
                return _letters ?? (
                                       _letters = TextResources.Letters.ToCharArray()
                                   );
            }
        }

        public IEnumerable<char> Numbers
        {
            get
            {
                return _numbers ?? (
                                       _numbers = TextResources.Numbers.ToCharArray()
                                   );
            }
        }

        public IEnumerable<string> PersonFirstNamesMale
        {
            get
            {
                return _personFirstNamesMale ??
                       (_personFirstNamesMale = PersonResources.FirstNamesMale.Split('\n'));
            }
        }

        public IEnumerable<string> PersonFirstNamesFemale
        {
            get
            {
                return _personFirstNamesFemale ??
                       (_personFirstNamesFemale = PersonResources.FirstNamesFemale.Split('\n'));
            }
        }

        public IEnumerable<TestingGenderTypes> DataGenders
        {
            get
            {
                return _dataGenders ??
                       (_dataGenders = Enum.GetValues(typeof (TestingGenderTypes)).Cast<TestingGenderTypes>());
            }
        }

        public IEnumerable<string> PersonLastNames
        {
            get
            {
                return _personLastNames ??
                       (_personLastNames = PersonResources.LastNames.Split('\n'));
            }
        }

        public IEnumerable<string> WebDomains
        {
            get
            {
                return _webDomains ??
                       (_webDomains = WebResources.Domains.Split('\n'));
            }
        }

        public IEnumerable<string> EmailTypes
        {
            get
            {
                return _emailTypes ??
                       (_emailTypes = WebResources.EmailTypes.Split('\n'));
            }
        }

        #endregion
    }
}