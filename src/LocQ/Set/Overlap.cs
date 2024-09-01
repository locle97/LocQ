public static class OverlapExtension
{
    public static IEnumerable<T> Overlap<T>(this IEnumerable<T> source, IEnumerable<T> other)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (other is null)
            throw new ArgumentNullException(nameof(other));

        HashSet<T> hs = new(other);
        foreach (var item in source)
        {
            if (hs.Contains(item))
                yield return item;
        }
    }

    public static IEnumerable<T> OverlapBy<T, TSelector>(this IEnumerable<T> source, IEnumerable<T> other, Func<T, TSelector> selector)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (other is null)
            throw new ArgumentNullException(nameof(other));

        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        HashSet<TSelector> hs = new(other.Map(selector));
        foreach (var item in source)
        {
            if (hs.Contains(selector(item)))
                yield return item;
        }
    }
}
