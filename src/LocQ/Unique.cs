public static class UniqueExtension
{
    public static IEnumerable<T> Unique<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        throw new NotImplementedException();
    }
}
