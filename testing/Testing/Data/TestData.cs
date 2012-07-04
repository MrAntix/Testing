using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Testing.Data.Resources;

namespace Testing.Data
{
    public static class TestData
    {
        static int _randomSeed = Environment.TickCount;

        // http://csharpindepth.com/Articles/Chapter12/Random.aspx
        static readonly ThreadLocal<Random> LocalRandom =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _randomSeed)));

        public static Random Random
        {
            get { return LocalRandom.Value; }
        }

        public static bool[] TrueFalse
        {
            get { return new[] {true, false}; }
        }

        #region Nested type: Email

        public class Email
        {
            public static string[] Types
            {
                get { return EmailResources.Types.Split('\n'); }
            }

            public string Type { get; set; }
            public string Address { get; set; }
        }

        #endregion

        #region Nested type: Person

        public class Person
        {
            #region GenderTypes enum

            public enum GenderTypes
            {
                Male,
                Female
            }

            #endregion

            public static GenderTypes[] Genders
            {
                get { return Enum.GetValues(typeof (GenderTypes)).Cast<GenderTypes>().ToArray(); }
            }

            public static string[] FirstNamesMale
            {
                get { return PersonResources.FirstNamesMale.Split('\n'); }
            }

            public static string[] FirstNamesFemale
            {
                get { return PersonResources.FirstNamesFemale.Split('\n'); }
            }

            public static string[] LastNames
            {
                get { return PersonResources.LastNames.Split('\n'); }
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public GenderTypes Gender { get; set; }

            public string FullName
            {
                get { return string.Format("{0} {1}", FirstName, LastName).Trim(); }
            }

            public IEnumerable<Email> Emails { get; set; }
        }

        #endregion

        #region Nested type: Web

        public class Web
        {
            public static string[] Domains
            {
                get { return WebResources.Domains.Split('\n'); }
            }

            public string Address { get; set; }
        }

        #endregion
    }
}