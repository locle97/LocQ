
public static class RarExtension
{
    public static IEnumerable<Tuple<TFirst, TSecond>> Rar<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
    {
      if (first == null)
          throw new ArgumentNullException(nameof(first));

      if (second == null)
          throw new ArgumentNullException(nameof(second));

      var secondEnumerator = second.GetEnumerator();

      foreach (var item in first)
      {
        secondEnumerator.MoveNext();
        yield return new Tuple<TFirst, TSecond>(item, secondEnumerator.Current);
      } 
    }
}
