using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class MapTest
{
    [Fact]
    public void GiveListOfNumber_WhenMapMethodIsCalledWithSquareFunction_ThenReturnListOfSquareNumber()
    {
        //Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //Act
        var result = numbers.Map(x => x * x);

        //Assert
        Assert.Equal(10, result.Count());
        Assert.Equal(new List<int> { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 }, result);
    }

    [Fact]
    public void GiveListOfString_WhenMapMethodIsCalledConcatWithHelloPrefix_ThenReturnListOfStringWithHelloPrefix()
    {
        //Arrange
        IEnumerable<string> data = new string[] { "World", "LocQ", "C#", "Dotnet" };

        //Act
        var result = data.Map(x => "Hello " + x);

        //Assert
        Assert.Equal(4, result.Count());
        foreach (var item in result)
        {
            Assert.StartsWith("Hello ", item);
        }
    }

    [Fact]
    public void GiveListOfObject_WhenMapMethodIsCalled_ReturnListOfObjectWithUpdatedValue()
    {
      //Arrange
      var data = new List<Person>
      {
          new Person { Name = "John", Age = 20 },
          new Person { Name = "Doe", Age = 30 },
          new Person { Name = "Jane", Age = 40 }
      };

      //Act
      var ages = data.Map(x => x.Age);

      //Assert
      Assert.Equal(3, ages.Count());

      int?[] listAges = ages.ToArray();
      for (int i = 0; i < listAges.Length; i++)
      {
          Assert.Equal(data[i].Age, listAges[i]);
      }
    }
}
