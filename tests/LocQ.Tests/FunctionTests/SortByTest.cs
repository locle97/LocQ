using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class SortByTest
{
    [Fact]
    public void SortBy_GivenListAndFunction_ThenReturnSortedList()
    {
        //Arrange
        var list = new List<int> { 2, 1, 4, 3, 5 };

        //Act
        var result = list.SortBy(x => x);

        //Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<int>{ 1, 2, 3, 4, 5 }, result);
    }
}
