public static class FlatMapExtension
{
    public static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> source,
                                                                Func<TSource, IEnumerable<TResult>> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        foreach (var item in source)
        {
            foreach (var subItem in selector(item))
            {
                yield return subItem;
            }
        }

    }

}
