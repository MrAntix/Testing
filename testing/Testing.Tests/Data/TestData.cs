namespace Testing.Tests.Data
{
    public static class TestData
    {
        #region Nested type: Person

        public static class Person
        {
            public static string[] FirstNames
            {
                get { return People.FirstNames.Split('\n'); }
            }

            public static string[] LastNames
            {
                get { return People.LastNames.Split('\n'); }
            }

            public static string[] Genders
            {
                get { return People.Genders.Split('\n'); }
            }
        }

        #endregion
    }
}