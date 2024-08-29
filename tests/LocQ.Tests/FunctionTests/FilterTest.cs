using LocQ.Filter;
using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class FilterTest
{
    [Fact]
    public void Filter_GiveListOfNumber_ThenReturnEvenNumber()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //Act
        var result = numbers.Filter(x => x % 2 == 0);

        //Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<int> { 2, 4, 6, 8, 10 }, result);
    }

    [Fact]
    public void Filter_GiveListOfNumber_ThenReturnOddNumbers()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //Act
        var result = numbers.Filter(x => x % 2 != 0);

        //Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<int> { 1, 3, 5, 7, 9 }, result);
    }

    [Fact]
    public void Filter_GiveAListOfString_ThenReturnListOfStringStartWith()
    {
        //Arrange
        List<string> listOfStrings = new() { "Foo", "Bar", "FooBar", "Hello", "World!" };

        //Act
        var result = listOfStrings.Filter(x => x.StartsWith("Foo"));

        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<string> { "Foo", "FooBar" }, result);
    }

    [Fact]
    public void Filter_GiveListOfObject_ThenReturnListOfObjectMatchConditions()
    {
        //Arrange
        List<Person> objects = new() {
          new Person { Age = 5, Name = "Five" },
          new Person { Age = 10, Name = "Ten" },
          new Person { Age = 15, Name = "Fifteen" },
          new Person { Age = 20, Name = "Twenty" }
        };

        //Act
        var result = objects.Filter(x => x.Age > 10);

        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<Person> {
          new Person { Age = 15, Name = "Fifteen" },
          new Person { Age = 20, Name = "Twenty" }
        }, result);

    }

    [Fact]
    public void Filter_GiveNull_ThrowAgrumentNullExceptions()
    {
        // Arrange
        List<object>? list = null;
        //Act
        var result = list.Filter(x => x != null);

        // Assert
        Assert.Throws<ArgumentNullException>(() => result.ToList());
    }

    [Fact]
    public void Filter_GiveNullPredicate_ThrowAgrumentNullExceptions()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //Act
        var result = numbers.Filter(null);

        // Assert
        Assert.Throws<ArgumentNullException>(() => result.ToList());
    }
}
