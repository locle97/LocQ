public static class SortByExtension
{
    public static IEnumerable<TSource> SortBy<TSource, TSelector>(this IEnumerable<TSource> source, 
                                                                    Func<TSource, TSelector> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);

        throw new NotImplementedException();
    }
}
