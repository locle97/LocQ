namespace LocQ.Set;

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
}
