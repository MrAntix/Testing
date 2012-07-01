Some code I use to help me do TDD

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