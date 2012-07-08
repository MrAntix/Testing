using System;
using System.Collections.Generic;
using Testing.Base;
using Testing.Models;

namespace Testing.Builders
{
    public interface IPersonBuilderResources
    {
        IEnumerable<string> PersonFirstNamesMale { get; }
        IEnumerable<string> PersonFirstNamesFemale { get; }
        IEnumerable<TestingGenderTypes> DataGenders { get; }
        IEnumerable<string> PersonLastNames { get; }

        IDateTimeBuilder DateTime { get; }
    }

    public class PersonBuilder : BuilderBase<PersonBuilder, TestingPersonModel>
    {
        readonly IDataContainer _dataContainer;

        public PersonBuilder(IDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            Assign = p =>
                         {
                             p.Gender = _dataContainer.Resources.DataGenders.OneOf();
                             p.FirstName = p.Gender == TestingGenderTypes.Female
                                               ? _dataContainer.Resources.PersonFirstNamesFemale.OneOf()
                                               : _dataContainer.Resources.PersonFirstNamesMale.OneOf();
                             p.LastName = _dataContainer.Resources.PersonLastNames.OneOf();

                             p.DateOfBirth = dataContainer.DateTime
                                 .With(DateTime.UtcNow.AddYears(-130), DateTime.UtcNow)
                                 .BuildItem();
                         };
        }

        public PersonBuilder WithAge(int min, int max)
        {
            return With(
                p =>
                    {
                        p.DateOfBirth = _dataContainer.DateTime
                            .With(DateTime.UtcNow.AddYears(-max), DateTime.UtcNow.AddYears(-min))
                            .BuildItem();
                    });
        }

        public PersonBuilder WithGender(TestingGenderTypes gender)
        {
            return With(
                p => { p.Gender = gender; });
        }

        protected override PersonBuilder CreateClone()
        {
            return new PersonBuilder(_dataContainer);
        }
    }
}