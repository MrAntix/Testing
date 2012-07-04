Some code I use to help me do TDD

[On NuGet](https://nuget.org/packages/antix-testing)

# Generic Builder

[Builder.cs](https://github.com/MrAntix/Testing/blob/master/testing/Testing/Builders/Builder.cs)

This is a generic builder class which separates off the business of creation into a reusable component
 - blogged about it: http://antix.co.uk/Blog/Generic-Builder

### Generic Builder Examples

    // create a builder for a mocked interface (using Moq)
    var builder = new Builder<IThingy>()
                    .Create(Mock.Of<IThingy>)
                    .With(x => 
                                {
                                    x.Name = "Some Name";
                                    x.SetValue("Some Value");
                                });
 
    // create an instance
    var instance = builder.Build();

    // create an other instance, override the name
    var otherInstance = builder.Build(x => x.Name = "Other Name");

    // create 100 instances, then 10 overriding the name
    var instances = builder
                        .Build(100)
                        .Build(10, x => x.Name = "Other Name")
                        .Items;

# Extensions

There a are some simple extensions to IEnumerable<T> to allow you to random elements

    // Gets a single random element from an IEnumerable<T>
    T OneOf<T>(this IEnumerable<T> items)

	// Gets an exact number of random elements from an IEnumerable<T>
	IEnumerable<T> ManyOf<T>(
            this IEnumerable<T> items, int exactCount)
			
	// Gets a random number of random elements from an IEnumerable<T> given a range
	IEnumerable<T> ManyOf<T>(
            this IEnumerable<T> items, int minCount, int maxCount)

# Test Data

There is also some test data, not much, I'll add as I go

    Testing.Data.TestData.General
	Testing.Data.TestData.Person

for example

    // get a random number of first names, between 10 and 20
	var firstNames = Testing.Data.TestData.Person.FirstNames
                        .ManyOf(10,20);