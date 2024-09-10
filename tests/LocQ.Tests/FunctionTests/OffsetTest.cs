using LocQ.Tests.Domains;

public class OffsetTest
{
    [Fact]
    public void Offset_With10Numbs_ShouldReturn5To9()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 10);
        var expected = new List<int> { 5, 6, 7, 8, 9 };

        // Act
        var actual = numbers.Offset(5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Offset_With10Numbs_ShouldReturn9()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 10);
        var expected = new List<int> { 9 };

        // Act
        var actual = numbers.Offset(9);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Offset_WithStrings_ReturnsStrings()
    {
        // Arrange
        var strings = new List<string> { "a", "b", "c", "d", "e" };
        var expected = new List<string> { "d", "e" };
        // Act
        var actual = strings.Offset(3);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Offset_WithStringsAndGreaterCount_ReturnsEmpty()
    {
        // Arrange
        var strings = new List<string> { "a", "b", "c", "d", "e" };
        var expected = new List<string> { };
        // Act
        var actual = strings.Offset(10);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public void Offset_WithNegativeCount_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 10);
        // Act
        Action act = () => numbers.Offset(-1);
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void Offset_GiveListPeople_ReturnsPeople()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, Name = "John", Age = 25 },
            new Person { Id = 2, Name = "Doe", Age = 30 },
            new Person { Id = 3, Name = "Jane", Age = 35 },
            new Person { Id = 4, Name = "Doe", Age = 40 },
            new Person { Id = 5, Name = "Jane", Age = 45 }
        };
        var expected = new List<Person>
        {
            new Person { Id = 4, Name = "Doe", Age = 40 },
            new Person { Id = 5, Name = "Jane", Age = 45 }
        };
        // Act
        var actual = people.Offset(3);

        // Assert
        Assert.Equal(expected, actual);
    }
}
