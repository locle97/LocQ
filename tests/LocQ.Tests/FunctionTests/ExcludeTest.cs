using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class ExcludeTest
{
    [Fact]
    public void Exclude_GiveTwoListOfNumbers_ThenReturnListOfNumbersExcludeFromOtherList()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var otherNumbers = new List<int> { 1, 3, 5, 7, 9 };
        //Act
        var result = numbers.Exclude(otherNumbers);
        //Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<int> { 2, 4, 6, 8, 10 }, result);
    }

    [Fact]
    public void Exclude_GiveTwoListOfStrings_ThenReturnListOfStringsExcludeFromOtherList()
    {
        //Arrange
        List<string> listOfStrings = new() { "Foo", "Bar", "FooBar", "Hello", "World!" };
        List<string> otherStrings = new() { "Foo", "FooBar" };
        //Act
        var result = listOfStrings.Exclude(otherStrings);
        //Assert
        Assert.Equal(3, result.Count());
        Assert.Equal(new List<string> { "Bar", "Hello", "World!" }, result);
    }

    [Fact]
    public void Exclude_GiveTwoListOfPerson_ThenReturnListOfPersonExcludeFromOtherList()
    {
        //Arrange
        List<Person> objects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 2, Age = 10, Name = "Ten" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" },
          new Person { Id = 4, Age = 20, Name = "Twenty" }
        };
        List<Person> otherObjects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" }
        };
        //Act
        var result = objects.Exclude(otherObjects);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 2, 4 }, result.Map(x => x.Id));
    }

    [Fact]
    public void ExcludeBy_GiveTwoListOfNumbers_ThenReturnListOfNumbersExcludeBySquare()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, -4, -5 };
        var otherNumbers = new List<int> { 1, -2, 4, 6 };
        //Act
        var result = numbers.ExcludeBy(otherNumbers, x => x * x);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 3, -5 }, result);
    }

    [Fact]
    public void ExcludeBy_GiveTwoListOfStrings_ThenReturnListOfStringsExcludeByLength()
    {
        //Arrange
        List<string> listOfStrings = new() { "Foo", "Bar", "FooBar", "Hello", "World!" };
        List<string> otherStrings = new() { "Foo", "Bar", "Hello" };
        //Act
        var result = listOfStrings.ExcludeBy(otherStrings, x => x.Length);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<string> { "FooBar", "World!" }, result);
    }

    [Fact]
    public void ExcludedBy_GiveTwoListOfPeople_ThenReturnListOfPeopleExcludeByAge()
    {
        //Arrange
        List<Person> objects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 2, Age = 10, Name = "Ten" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" },
          new Person { Id = 4, Age = 20, Name = "Twenty" }
        };
        List<Person> otherObjects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" }
        };
        //Act
        var result = objects.ExcludeBy(otherObjects, x => x.Age);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 2, 4 }, result.Map(x => x.Id));
    }

    [Fact]
    public void ExcludedBy_GiveTwoListOfPeople_ThenReturnListOfPeopleExcludeByName()
    {
        //Arrange
        List<Person> objects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 2, Age = 10, Name = "Ten" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" },
          new Person { Id = 4, Age = 20, Name = "Twenty" }
        };
        List<Person> otherObjects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" }
        };
        //Act
        var result = objects.ExcludeBy(otherObjects, x => x.Name);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 2, 4 }, result.Map(x => x.Id));
    }
}
