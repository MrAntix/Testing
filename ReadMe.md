Some code I use to help me do TDD

# Generic Builder

[Builder.cs](https://github.com/MrAntix/Testing/blob/master/antix-testing/Antix.Testing/Builder.cs)

This is a generic builder class which separates off the business of creation into a reusable component

[On NuGet](https://nuget.org/packages/antix-testing)

### Generic Builder Examples

    // create a builder for a mocked interface (using Moq)
    var builder = new Builder<IThingy>(Mock.Of<IThingy>)
                    .With(x => 
                                {
                                    x.Name = "Some Name";
                                    x.SetValue("Some Value");
                                });
 
    // create an instance
    var instance = builder.Build();

    // create an other instance, override the name
    var otherInstance = builder
	                    .Build(x => x.Name = "Other Name");

    // create 100 instances, then 10 overriding the name, the index is supplied too
    var instances = builder
                        .Build(100)
                        .Build(10, (x, i) => x.Name = "Other Name")
						.ToList();

### Notes on Usage

The builder implements IEnumerable<T> and is has a lazy iterator, which means everytime 
you enumerate it you will get a new set of objects

Call .ToArray() or .ToList() to fix a set to a variable (see above)

# Standard Builders

These are some builders to get hold of the usual type of data you may need

    IBooleanBuilder Boolean { get; }
    IIntegerBuilder Integer { get; }
    IDoubleBuilder Double { get; }
    IDateTimeBuilder DateTime { get; }
    ITextBuilder Text { get; }

    IPersonBuilder Person { get; }
    IEmailBuilder Email { get; }
    IWebsiteBuilder Website { get; }

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

Also some extensions to find embedded resources

	// Find an embedded resource as a stream in the passed type assembly by name
    Stream FindResourceStream(this Type type, string name)

	// Find an embedded resource and transform from stream to another type
    T FindResource<T>(this Type type, string name, Func<Stream, T> transformer)

	// Find an embedded resource and transform to a string
    string FindResourceString(this Type type, string name)

	// Find an embedded resource and transform to an image
    Image FindResourceImage(this Type type, string name)

# Test Data

There is also some test data

    IEnumerable<bool> Booleans { get; }

    IEnumerable<string> PersonFirstNamesMale { get; }
    IEnumerable<string> PersonFirstNamesFemale { get; }
    IEnumerable<GenderTypes> DataGenders { get; }
    IEnumerable<string> PersonLastNames { get; }

    IEnumerable<string> WebDomains { get; }
    IEnumerable<string> EmailTypes { get; }

    IEnumerable<char> Chars { get; }
    IEnumerable<char> Letters { get; }
    IEnumerable<char> Numbers { get; }

for example

    // get a random number of male first names, between 10 and 20
	var firstNames = TestData.PersonFirstNamesMale
                        .ManyOf(10,20);

# Benchmarking

This is used to time how long a piece of code takes to run.

Wrap your code in a delegate and call the Benchmark.Run with a number 
of iterations or even a list of iteration to get figures for performance
over an increasing number of iterations

    var result = Benchmark
        .Run(() => [Your Action], [Number of iterations]);

for example, run Thread.Sleep 10 times

    var result = Benchmark
        .Run(() => Thread.Sleep(10), 10);

for example, run Thread.Sleep 10 times, 100 times and 1000 times

    var result = Benchmark
        .Run(() => Thread.Sleep(10), 10, 100, 1000);

The result ToString() gives a summary of the timings including the average
and you can format this using config (see app.config in the Testing project)

    <Testing.Properties.Settings>
        <setting name="BenchmarkResult_toString" serializeAs="String">
            <value>{0}, av {1}, {2}x</value>
        </setting>
        <setting name="BenchmarkResultList_toString" serializeAs="String">
            <value>{0}, av {1}, {2}x</value>
        </setting>
    </Testing.Properties.Settings>

{0} time
{1} average
{2} iterations