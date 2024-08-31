using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class UniqueByTest
{
    [Fact]
    public void UniqueBy_ListDuplicatedNumbers_ListUniqueNumbersBySquare()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 1, 3, 3, 4, 5, 5, 5 };

        // Act
        var result = numbers.UniqueBy(x => x * 2);

        // Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void UniqueBy_ListDuplicatedString_ListUniqueStringByReversedString()
    {
        // Arrange
        var str = new List<string> {
          "Hello",
          "World",
          "Foo",
          "ooF",
          "Foo",
          "ooF"
        };

        // Act
        var result = str.UniqueBy(x => x);

        // Assert
        Assert.Equal(4, result.Count());
        Assert.Equal(new List<string> { "Hello", "World", "Foo", "ooF" }, result);
    }

    [Fact]
    public void UniqueBy_ListPeoples_ListPeopleUniqueByAge()
    {
        // Arrange
        var str = new List<Person> {
          new Person { Id = 1, Name = "Tom", Age = 10 },
          new Person { Id = 2, Name = "Jerry", Age = 20 },
          new Person { Id = 3, Name = "Foo", Age = 10 },
          new Person { Id = 4, Name = "Bar", Age = 30 }
        };

        // Act
        var result = str.UniqueBy(x => x.Age);
        var arr = result.ToArray();

        // Assert
        Assert.Equal(3, arr.Length);
        foreach (var item in arr)
        {
            Assert.True(item.Age is 10 or 20 or 30);
            Assert.True(item.Id is 1 or 2 or 4);
        }
    }

    [Fact]
    public void UniqueBy_ListPeoples_ListPeopleUniqueById()
    {
        // Arrange
        var str = new List<Person> {
          new Person { Id = 1, Name = "Tom", Age = 10 },
          new Person { Id = 2, Name = "Jerry", Age = 20 },
          new Person { Id = 3, Name = "Foo", Age = 10 },
          new Person { Id = 4, Name = "Bar", Age = 30 },
          new Person { Id = 4, Name = "Test", Age = 40 }
        };

        // Act
        var result = str.UniqueBy(x => x.Id);
        var arr = result.ToArray();

        // Assert
        Assert.Equal(4, arr.Length);
        foreach (var item in arr)
        {
            Assert.True(item.Age is 10 or 20 or 30);
            Assert.True(item.Id is 1 or 2 or 3 or 4);
        }
    }

    [Fact]
    public void UniqueBy_ListNull_ThrowArgumentException()
    {
        // Arrange
        List<Person>? str = null;

        // Act
        var result = str.UniqueBy(x => x.Name);

        // Assert
        Assert.Throws<ArgumentNullException>(() => result.ToArray());
    }

    [Fact]
    public void UniqueBy_ListPeoples_ListPeopleUniqueByName()
    {
        // Arrange
        var str = new List<Person> {
          new Person { Id = 1, Name = "Tom", Age = 10 },
          new Person { Id = 2, Name = "Jerry", Age = 20 },
          new Person { Id = 3, Name = "Foo", Age = 10 },
          new Person { Id = 4, Name = "Foo", Age = 10 },
          new Person { Id = 5, Name = "Bar", Age = 30 },
          new Person { Id = 6, Name = "Bar", Age = 30 }
        };

        // Act
        var result = str.UniqueBy(x => x.Name);
        var arr = result.ToArray();

        // Assert
        Assert.Equal(4, arr.Length);
        foreach (var item in arr)
        {
            Assert.True(item.Name is "Foo" or "Bar" or "Tom" or "Jerry");
        }
    }
}
