namespace LocQ.Tests.Domains;

public sealed class Person
{
    public int? Age { get; set; }
    public string? Name { get; set; }

    public IEnumerable<Person> Children { get; set; } = new List<Person>();
    public IEnumerable<string?> ChildrenNames => Children.Select(x => x.Name);

    public override bool Equals(object? obj)
    {
        return obj is Person sampleClass && Age == sampleClass.Age && Name == sampleClass.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Age, Name);
    }
}

