public static class SortExtension
{
    public static IEnumerable<T> SortBy<T, TSort>(this IEnumerable<T> source, Func<T, TSort> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

    }
}
