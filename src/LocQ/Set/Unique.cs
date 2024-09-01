public static class UniqueExtension
{
    public static IEnumerable<T> Unique<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        HashSet<T> set = new HashSet<T>();
        foreach (var item in source)
        {
            if (set.Contains(item))
                continue;

            set.Add(item);
            yield return item;
        }
    }

    public static IEnumerable<T> UniqueBy<T, TDes>(this IEnumerable<T> source, Func<T, TDes> selector)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        HashSet<TDes> set = new();

        foreach (var item in source)
        {
            if (set.Contains(selector(item)))
                continue;

            set.Add(selector(item));
            yield return item;
        }
    }
}
