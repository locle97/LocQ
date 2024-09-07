public static class EveryExtension
{
    public static bool Every<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        var enumerator = source.GetEnumerator();
        while(enumerator.MoveNext())
        {
            if(!predicate(enumerator.Current))
            {
                return false;
            }
        }

        return true;
    }
}
