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

    [Fact]
    public void SortBy_GivenListOfStrings_ThenReturnSortedList()
    {
        //Arrange
        var list = new List<string> { "B", "A", "D", "C", "E" };
        //Act
        var result = list.SortBy(x => x);
        //Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<string>{ "A", "B", "C", "D", "E" }, result);
    }

    [Fact]
    public void SortBy_GivenNullList_ThenThrowArgumentNullException()
    {
        //Arrange
        List<int> list = null!;

        //Act
        Action act = () => list.SortBy(x => x);

        //Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void SortBy_GivenNullSelector_ThenThrowArgumentNullException()
    {
        //Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };

        //Act
        Action act = () => SortByExtension.SortBy<int, object>(list, null!);

        //Assert
        Assert.Throws<ArgumentNullException>(act);
    }
}
