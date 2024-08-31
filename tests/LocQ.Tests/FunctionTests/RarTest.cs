using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class RarTest
{
    [Fact]
    public void Rar_WhenCalledWithTwoLists_ThenReturnTupleOfTwoLists()
    {
        //Arrange
        var first = new List<int> { 1, 2, 3, 4, 5 };
        var second = new List<int> { 6, 7, 8, 9, 10 };
        //Act
        var result = first.Rar(second);
        //Assert
        var listResult = result.ToList();
        for (int i = 0; i < listResult.Count; i++)
        {
            Assert.IsType<Tuple<int, int>>(listResult[i]);
            Assert.Equal(first[i], listResult[i].Item1);
            Assert.Equal(second[i], listResult[i].Item2);
        }

    }

    [Fact]
    public void Rar_2ListsOfNumbersAndString_ThenReturnTupleOfTwoLists()
    {
        //Arrange
        var first = new List<int> { 1, 2, 3, 4, 5 };
        var second = new List<string> { "A", "B", "C", "D", "E", "F" };

        //Act
        var result = first.Rar(second);
        var listResult = result.ToList();

        //Assert
        for (int i = 0; i < listResult.Count; i++)
        {
            Assert.IsType<Tuple<int, string>>(listResult[i]);
            Assert.Equal(first[i], listResult[i].Item1);
            Assert.Equal(second[i], listResult[i].Item2);
        }
    }
}
