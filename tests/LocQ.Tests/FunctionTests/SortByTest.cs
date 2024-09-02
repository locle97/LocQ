using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class SortByTest
{
    [Fact]
    public void SortBy_WhenCalledWithListOfIntegers_ThenReturnSortedList()
    {
        //Arrange
        var list = new List<int> { 5, 3, 1, 4, 2 };
        //Act
        var result = list.SortBy(x => x);
        //Assert
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result.ToList());
    }

    [Fact]
    public void SortBy_WhenCalledWithListOfStrings_ThenReturnSortedList()
    {
        //Arrange
        var list = new List<string> { "E", "C", "A", "D", "B" };
        //Act
        var result = list.SortBy(x => x);
        //Assert
        Assert.Equal(new List<string> { "A", "B", "C", "D", "E" }, result.ToList());
    }
}
