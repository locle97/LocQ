public static class MergeExtension
{
    public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> other)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (other == null)
            throw new ArgumentNullException(nameof(other));

        HashSet<T> hs = new();
        foreach (T item in source)
        {
            if(hs.Add(item))
                yield return item;
        }

        foreach (T item in other)
        {
            if(hs.Add(item))
                yield return item;
        }
    }
}
