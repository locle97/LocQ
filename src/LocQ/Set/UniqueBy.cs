public static class UniqueByExtension
{
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
