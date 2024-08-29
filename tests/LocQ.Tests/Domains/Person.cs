namespace LocQ.Tests.Domains;

public sealed class Person
{
    public int Id { get; set; } = -1;
    public int? Age { get; set; }
    public string? Name { get; set; }

    public IEnumerable<Person> Children { get; set; } = new List<Person>();
    public IEnumerable<string?> ChildrenNames => Children.Select(x => x.Name);

    public override bool Equals(object? obj)
    {
        return obj is Person sampleClass 
              && Id == sampleClass.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}

