using LocQ.Tests.Domains;

namespace LocQ.Tests.FunctionTests;

public class FlatMapTest
{
    [Fact]
    public void FlatMap_ListPerson_ListChildren()
    {
        // Arrange
        var list = new List<Person> {
          new Person { Name = "John", Age = 20, Children = new List<Person> { new Person { Name = "John Jr", Age = 1 } } },
          new Person { Name = "Jane", Age = 30, Children = new List<Person> { new Person { Name = "Jane Jr", Age = 2 }, new Person { Name = "Jane Sn", Age = 4} } },
          new Person { Name = "Jack", Age = 40, Children = new List<Person> { new Person { Name = "Jack Jr", Age = 3 } } },
        };

        // Act
        IEnumerable<Person> result = list.FlatMap(x => x.Children);

        // Assert
        Assert.Equal(4, result.Count());
    }
}
