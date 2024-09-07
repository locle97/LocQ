public class IncludesTest
{
    [Fact]
    public void Includes_WhenSourceIsNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> source = null!;
        Func<int, bool> predicate = x => x > 0;
        Assert.Throws<ArgumentNullException>(() => source.Includes(0));
    }

    [Theory]
    [MemberData(nameof(GetTestCasesNumber))]
    public void Includes_WithNumbersPredicate_ReturnsExpectedResult(IEnumerable<int> source, int item, bool expectedResult)
    {
        var result = source.Includes(item);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(GetTestCasesString))]
    public void Includes_WithStringsPredicate_ReturnsExpectedResult(IEnumerable<string> source, string item, bool expectedResult)
    {
        var result = source.Includes(item);
        Assert.Equal(expectedResult, result);
    }

    public static IEnumerable<object[]> GetTestCasesNumber()
    {
        yield return new object[] { Enumerable.Range(1, 10), 1, true };
        yield return new object[] { Enumerable.Range(1, 10), 0, false };
        yield return new object[] { Enumerable.Range(1, 10), 11, false };
        yield return new object[] { Enumerable.Empty<int>(), 0, false };
    }

    public static IEnumerable<object[]> GetTestCasesString()
    {
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, "Foo", true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, "FOO", false };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, "Bar", true };
        yield return new object[] { new string[] { "Foo", "Bar", "Hello", "World!" }, "Hello", true };
        yield return new object[] { new string[] {  }, "Foo", false };
    }
}
