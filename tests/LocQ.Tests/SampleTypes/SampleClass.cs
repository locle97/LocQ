namespace LocQ.Tests.SampleTypes;

public sealed class SampleClass
{
    public int Value { get; set; }
    public string? Name { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is SampleClass sampleClass && Value == sampleClass.Value && Name == sampleClass.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Name);
    }
}

