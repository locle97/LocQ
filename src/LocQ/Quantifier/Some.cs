public static class SomeExtension
{
    public static bool Some<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        var enumerator = source.GetEnumerator();
        while(enumerator.MoveNext())
        {
            if(predicate(enumerator.Current))
            {
                return true;
            }
        }

        return false;
    }
}

