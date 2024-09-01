using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class MergeTest
{
    [Fact]
    public void Merge_GiveTwoListOfNumbers_ThenReturnListOfNumbersMergeUnique()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var otherNumbers = new List<int> { 1, 2, 4, 6 };
        //Act
        var result = numbers.Merge(otherNumbers);
        //Assert
        Assert.Equal(6, result.Count());
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Fact]
    public void Merge_GiveTwoListOfNumbersWithNonUnique_ThenReturnListOfNumbersMerge()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 2, 3, 3, 4, 5 };
        var otherNumbers = new List<int> { 1, 2, 4, 6 };
        //Act
        var result = numbers.Merge(otherNumbers);
        //Assert
        Assert.Equal(6, result.Count());
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Fact]
    public void Merge_GiveTwoListOfStrings_ThenReturnListOfStringsMergeUnique()
    {
        // Arrange
        List<string> listOfStrings = new() { "Foo", "Bar", "FooBar", "World!" };
        List<string> otherStrings = new() { "Foo", "Bar", "Hello" };
        // Act
        var result = listOfStrings.Merge(otherStrings);
        // Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<string> { "Foo", "Bar", "FooBar", "World!", "Hello" }, result);
    }

    [Fact]
    public void Merge_GiveTwoListOfStringsWithNonUnique_ThenReturnListOfStringsMerge()
    {
        // Arrange
        List<string> listOfStrings = new() { "Foo", "Foo", "Bar", "FooBar", "World!" };
        List<string> otherStrings = new() { "Bar", "Hello" };
        // Act
        var result = listOfStrings.Merge(otherStrings);
        // Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<string> { "Foo", "Bar", "FooBar", "World!", "Hello" }, result);
    }

    [Fact]
    public void Merge_GiveTwoListOfPeople_ThenReturnListOfPeopleMergeUnique()
    {
        // Arrange
        List<Person> listOfPeople = new() { 
            new Person { Id = 1, Name = "Foo", Age = 20 }, 
            new Person { Id = 2, Name = "Bar", Age = 30 } 
        };
        List<Person> otherPeople = new() { 
            new Person { Id = 1, Name = "Foo", Age = 20 }, 
            new Person { Id = 3, Name = "Hello", Age = 40 } 
        };
        // Act
        var result = listOfPeople.Merge(otherPeople);
        // Assert
        Assert.Equal(3, result.Count());
        Assert.Equal(new List<int> { 1, 2, 3 }, result.Map(t => t.Id));
    }
}
