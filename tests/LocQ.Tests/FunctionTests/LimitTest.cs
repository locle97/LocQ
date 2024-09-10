using LocQ.Tests.Domains;

public class LimitTest
{
    [Fact]
    public void Limit_With10Numbs_ShouldReturn5To9()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 10);
        var expected = new List<int> { 0, 1, 2, 3, 4 };

        // Act
        var actual = numbers.Limit(5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Limit_With10Numbs_ShouldReturn9()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 10);
        var expected = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        // Act
        var actual = numbers.Limit(9);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Limit_WithStrings_ReturnsStrings()
    {
        // Arrange
        var strings = new List<string> { "a", "b", "c", "d", "e" };
        var expected = new List<string> { "a", "b", "c" };
        // Act
        var actual = strings.Limit(3);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Limit_WithStringsAndGreaterCount_ReturnsEmpty()
    {
        // Arrange
        var strings = new List<string> { "a", "b", "c", "d", "e" };

        // Act
        var actual = strings.Limit(10);

        // Assert
        Assert.Equal(strings, actual);
    }

    [Fact]
    public void Limit_WithNegativeCount_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 10);
        // Act
        Action act = () => numbers.Limit(-1);
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void Limit_GiveListPeople_ReturnsPeople()
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
            new Person { Id = 1, Name = "John", Age = 25 },
            new Person { Id = 2, Name = "Doe", Age = 30 },
            new Person { Id = 3, Name = "Jane", Age = 35 },
        };
        // Act
        var actual = people.Limit(3);

        // Assert
        Assert.Equal(expected, actual);
    }
}
