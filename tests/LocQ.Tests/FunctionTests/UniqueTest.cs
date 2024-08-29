using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class UniqueTest
{
    [Fact]
    public void Unique_ListDuplicatedNumbers_ListUniqueNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 1, 3, 3, 4, 5, 5, 5 };

        // Act
        var result = numbers.Unique();

        // Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void Unique_ListDuplicatedString_ListUniqueStrings()
    {
        // Arrange
        var items = new List<string> { "Foo", "Bar", "Foo", "Hello", "Hello", "World!", "World!", "World!" };

        // Act
        var result = items.Unique();

        // Assert
        Assert.Equal(4, result.Count());
        Assert.Equal(new List<string> { "Foo", "Bar", "Hello", "World!" }, result);
    }

    [Fact]
    public void Unique_DuplicatedPeople_ListUniquePersons()
    {
        // Arrange
        var items = new List<Person> {
          new Person { Id = 1, Name = "Foo", Age = 10 },
          new Person { Id = 2, Name = "Bar", Age = 20 },
          new Person { Id = 1, Name = "Foo", Age = 10 },
          new Person { Id = 3, Name = "Bar", Age = 30 },
          new Person { Id = 4, Name = "Hello", Age = 40 },
          new Person { Id = 3, Name = "Bar", Age = 20 },
        };

        // Act
        var result = items.Unique();

        // Assert
        Assert.Equal(4, result.Count());
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, result.Map(x => x.Id));
    }
}
