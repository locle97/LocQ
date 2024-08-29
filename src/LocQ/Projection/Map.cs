namespace LocQ.Projection;

public static class MapExtension
{
    public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source,
                                                              Func<TSource, TResult> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        foreach (var item in source)
        {
            yield return selector(item);
        }
    }
}
