using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class FlatMapTest
{
    [Fact]
    public void FlatMap_ListPerson_ListChildren()
    {
        // Arrange
        var list = GetSamplePersons();
        var expected = GetExpectedChildrenNames();

        // Act
        IEnumerable<Person> result = list.FlatMap(x => x.Children);

        // Assert
        Assert.Equal(4, result.Count());
        foreach (var item in result)
        {
            Assert.Contains(item.Name, expected);
        }
    }

    [Fact]
    public void FlatMap_ListPerson_ListChildrenNames()
    {
        // Arrange
        var list = GetSamplePersons();
        var expected = GetExpectedChildrenNames();

        // Act
        IEnumerable<string?> result = list.FlatMap(x => x.ChildrenNames);

        // Assert
        Assert.Equal(list.Count(), result.Count());
        foreach (var item in result)
        {
            Assert.Contains(item, expected);
        }
    }

    [Fact]
    public void FlatMap_ListPerson_ListChildrenAges()
    {
        // Arrange
        List<Person> list = GetSamplePersons();
        List<int> expected = GetExpectedChildrenAges();

        // Act
        IEnumerable<int?> result = list.FlatMap(x => x.Children.Map(c => c.Age));

        // Assert
        Assert.Equal(list.Count(), result.Count());
        foreach (var item in result)
        {
            Assert.Contains(item.Value, expected);
        }
    }

    [Fact]
    public void FlatMap_SourceNull_ThrowArgumentNullException()
    {
      // Arrange
      List<Person>? list = null;

      // Act
      var result = list.FlatMap(x => x.Children);

      // Assert
      Assert.Throws<ArgumentNullException>(() => result.ToList());
    }

    private List<string> GetExpectedChildrenNames()
    {
      return new List<string> { "John Jr", "Jane Jr", "Jane Sn", "Jack Jr", "Jack Sn" };
    }

    private List<int> GetExpectedChildrenAges()
    {
      return new List<int> { 1, 2, 4, 3, 5 };
    }

    private static List<Person> GetSamplePersons()
    {
        return new List<Person> {
          new Person { Name = "John", Age = 20, Children = new List<Person> { new Person { Name = "John Jr", Age = 1 } } },
          new Person { Name = "Jane", Age = 30, Children = new List<Person> { new Person { Name = "Jane Jr", Age = 2 }, new Person { Name = "Jane Sn", Age = 4} } },
          new Person { Name = "Jack", Age = 40, Children = new List<Person> { new Person { Name = "Jack Jr", Age = 3 }, new Person { Name = "Jack Sn", Age = 5} } },
        };
    }

}
