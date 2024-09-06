using System.Linq;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser(true)]
public class SortTest
{
    private static int[] array = Enumerable.Range(0, 10_000_000).ToArray();

    [Benchmark]
    public void LinQSort()
    {
        foreach (var item in array.OrderBy(t => t * t)) { }
    }

    [Benchmark]
    public void LocQSortBy()
    {
        foreach (var item in array.SortBy(t => t * t)) { }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<SortTest>();
    }
}
