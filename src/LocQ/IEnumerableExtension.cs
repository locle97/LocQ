namespace LocQ;

public static class IEnumerableExtension
{
    public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

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

    public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> source,
                                                                Func<TSource, IEnumerable<TResult>> selector)
    {
       throw new NotImplementedException();
    }
}
