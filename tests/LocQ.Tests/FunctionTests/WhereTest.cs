using LocQ.Tests.SampleTypes;

namespace LocQ.Tests.FunctionTests;

public class WhereTest
{
    [Fact]
    public void GiveListOfNumber_WhenFilterMethodIsCalledWithEvenPredicate_ThenReturnEvenNumber()
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
    public void GiveListOfNumber_WhenFilterMethodIsCalledWithOddPredicate_ThenReturnOddNumbers()
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
    public void GiveAListOfString_WhenFilterMethodIsCalledWithStartWithPredicate_ThenReturnListOfStringStartWith()
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
    public void GiveListOfObject_WhenFilterWithValueGreaterThan10_ThenReturnListOfObjectMatchConditions()
    {
        //Arrange
        List<SampleClass> objects = new() {
          new SampleClass { Value = 5, Name = "Five" },
          new SampleClass { Value = 10, Name = "Ten" },
          new SampleClass { Value = 15, Name = "Fifteen" },
          new SampleClass { Value = 20, Name = "Twenty" }
        };

        //Act
        var result = objects.Filter(x => x.Value > 10);

        //Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(new List<SampleClass> {
          new SampleClass { Value = 15, Name = "Fifteen" },
          new SampleClass { Value = 20, Name = "Twenty" }
        }, result);

    }

    [Fact]
    public void GiveNull_WhenFilterMethodIsCalled_ThrowAgrumentNullExceptions()
    {
        //Act
        var result = IEnumerableExtension.Filter<object>(null, x => x != null);

        // Assert
        Assert.Throws<ArgumentNullException>(() => result.ToList());
    }

    [Fact]
    public void GiveNullPredicate_WhenFilterMethodIsCalled_ThrowAgrumentNullExceptions()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //Act
        var result = IEnumerableExtension.Filter<int>(numbers, null);

        // Assert
        Assert.Throws<ArgumentNullException>(() => result.ToList());
    }
}
