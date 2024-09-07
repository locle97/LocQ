public class SomeTest
{
    [Fact]
    public void Some_WhenSourceIsNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> source = null!;
        Func<int, bool> predicate = x => x > 0;
        Assert.Throws<ArgumentNullException>(() => source.Some(predicate));
    }

    [Fact]
    public void Some_WhenPredicateIsNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> source = Enumerable.Range(1, 10);
        Assert.Throws<ArgumentNullException>(() => source.Some(null!));
    }

    [Theory]
    [MemberData(nameof(GetTestCasesNumber))]
    public void Some_WithNumbersPredicate_ReturnsExpectedResult(IEnumerable<int> source, Func<int, bool> predicate, bool expectedResult)
    {
        var result = source.Some(predicate);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(GetTestCasesString))]
    public void Some_WithStringsPredicate_ReturnsExpectedResult(IEnumerable<string> source, Func<string, bool> predicate, bool expectedResult)
    {
        var result = source.Some(predicate);
        Assert.Equal(expectedResult, result);
    }

    public static IEnumerable<object[]> GetTestCasesNumber()
    {
        yield return new object[] { Enumerable.Range(1, 10), new Func<int, bool>(x => x > 0), true };
        yield return new object[] { Enumerable.Range(1, 10), new Func<int, bool>(x => x < 0), false };
        yield return new object[] { Enumerable.Range(1, 10), new Func<int, bool>(x => x >= 10), true };
        yield return new object[] { Enumerable.Empty<int>(), new Func<int, bool>(x => x >= 10), false };
    }

    public static IEnumerable<object[]> GetTestCasesString()
    {
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.StartsWith("F")), true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.StartsWith("A")), false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.StartsWith("Hello")), true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.Contains("!")), true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x.Contains("@")), false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x == "Foo"), true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, new Func<string, bool>(x => x == "FooBar"), false };
        yield return new object[] { new string[] {  }, new Func<string, bool>(x => x.Contains("@")), false };
    }
}
