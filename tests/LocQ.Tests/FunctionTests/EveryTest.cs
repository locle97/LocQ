public class EveryTest
{
    [Fact]
    public void Every_WhenSourceIsNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> source = null!;
        Func<int, bool> predicate = x => x > 0;
        Assert.Throws<ArgumentNullException>(() => source.Every(predicate));
    }

    [Fact]
    public void Every_WhenPredicateIsNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> source = Enumerable.Range(1, 10);
        Assert.Throws<ArgumentNullException>(() => source.Every(null!));
    }

    [Theory]
    [MemberData(nameof(GetTestCasesNumber))]
    public void Every_WithNumbersPredicate_ReturnsExpectedResult(IEnumerable<int> source, Func<int, bool> predicate, bool expectedResult)
    {
        var result = source.Every(predicate);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(GetTestCasesString))]
    public void Every_WithStringsPredicate_ReturnsExpectedResult(IEnumerable<string> source, Func<string, bool> predicate, bool expectedResult)
    {
        var result = source.Every(predicate);
        Assert.Equal(expectedResult, result);
    }

    public static IEnumerable<object[]> GetTestCasesNumber()
    {
        yield return new object[] { Enumerable.Range(1, 10), new Func<int, bool>(x => x > 0), true };
        yield return new object[] { Enumerable.Range(1, 10), new Func<int, bool>(x => x < 0), false };
        yield return new object[] { Enumerable.Range(1, 10), new Func<int, bool>(x => x >= 10), false };
        yield return new object[] { Enumerable.Empty<int>(), new Func<int, bool>(x => x >= 10), true };
    }

    public static IEnumerable<object[]> GetTestCasesString()
    {
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.StartsWith("F")), false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.StartsWith("A")), false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.StartsWith("Hello")), false };
        yield return new object[] { new string[] { "F!oo", "!Bar", "Hel!lo", "World!" }, new Func<string, bool>(x => x.Contains("!")), true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.Contains("@")), false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x == "Foo"), false };
        yield return new object[] { new string[] { "Foo", "Foo", "Foo", "Foo" }, new Func<string, bool>(x => x == "Foo"), true };
        yield return new object[] { new string[] { "Foo!", "Foo", "Foo", "Foo" }, new Func<string, bool>(x => x == "Foo"), false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x == "FooBar"), false };
        yield return new object[] { new string[] { "Foo", "Bar" }, new Func<string, bool>(x => x == "Foo" || x == "Bar"), true };
        yield return new object[] { new string[] {  }, new Func<string, bool>(x => x.Contains("@")), true };
    }
}
