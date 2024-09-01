using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class OverlapTest
{
    [Fact]
    public void Overlap_GiveTwoListOfNumbers_ThenReturnListOfNumbersOverlap()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var otherNumbers = new List<int> { 1, 2, 4, 6 };
        //Act
        var result = numbers.Overlap(otherNumbers);
        //Assert
        Assert.Equal(3, result.Count());
        Assert.Equal(new List<int> { 1, 2, 4 }, result);
    }

    [Fact]
    public void Overlap_GiveTwoListOfStrings_ThenReturnListOfStringsOverlap()
    {
        //Arrange
        List<string> listOfStrings = new() { "Foo", "Bar", "FooBar", "World!" };
        List<string> otherStrings = new() { "Foo", "Bar", "Hello" };
        //Act
        var result = listOfStrings.Overlap(otherStrings);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<string> { "Foo", "Bar" }, result);
    }

    [Fact]
    public void Overlap_GiveTwoListOfPerson_ThenReturnListOfPersonOverlap()
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
        var result = objects.Overlap(otherObjects);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 1, 3 }, result.Map(x => x.Id));
    }

    [Fact]
    public void OverlapBy_GiveTwoListOfNumbers_ThenReturnListOfNumbersOverlapBySquare()
    {
        //Arrange
        var numbers = new List<int> { 1, -2, 3, 4, 5 };
        var otherNumbers = new List<int> { 1, 2, -4, 6 };
        //Act
        var result = numbers.OverlapBy(otherNumbers, x => x * x);
        //Assert
        Assert.Equal(3, result.Count());
        Assert.Equal(new List<int> { 1, -2, 4 }, result);
    }

    [Fact]
    public void OverlapBy_GiveTwoListOfStrings_ThenReturnListOfStringsOverlapByLength()
    {
        //Arrange
        List<string> listOfStrings = new() { "Foo", "Bar", "FooBar", "World!", "A" };
        List<string> otherStrings = new() { "Foo", "Bar", "Hello!", "AB" };
        //Act
        var result = listOfStrings.OverlapBy(otherStrings, x => x.Length);
        //Assert
        Assert.Equal(4, result.Count());
        Assert.Equal(new List<string> { "Foo", "Bar", "FooBar", "World!" }, result);
    }

    [Fact]
    public void OverlapBy_GiveTwoListOfPeople_ThenReturnListOfPeopleOverlapByAge()
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
        var result = objects.OverlapBy(otherObjects, x => x.Age);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 1, 3 }, result.Map(x => x.Id));
    }

    [Fact]
    public void OverlapBy_GiveTwoListOfPeople_ThenReturnListOfPeopleOverlapByName()
    {
        //Arrange
        List<Person> objects = new() {
          new Person { Id = 1, Age = 5, Name = "Five" },
          new Person { Id = 2, Age = 10, Name = "Ten" },
          new Person { Id = 3, Age = 15, Name = "Fifteen" },
          new Person { Id = 4, Age = 20, Name = "Twenty" }
        };
        List<Person> otherObjects = new() {
          new Person { Id = 5, Age = 7, Name = "Five" },
          new Person { Id = 6, Age = 8, Name = "Fifteen" }
        };
        //Act
        var result = objects.OverlapBy(otherObjects, x => x.Name);
        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<int> { 1, 3 }, result.Map(x => x.Id));
    }
}
