public static class IncludesExtension
{
    public static bool Includes<T>(this IEnumerable<T> source, T value)
    {
        ArgumentNullException.ThrowIfNull(source);

        // Throw if T is not having comparison operators
        if(!typeof(T).IsPrimitive && !typeof(T).IsValueType && !typeof(T).IsEnum && typeof(T) != typeof(string))
        {
            throw new InvalidOperationException("T must have comparison operators");
        }

        var enumerator = source.GetEnumerator();

        while(enumerator.MoveNext())
        {
            if(EqualityComparer<T>.Default.Equals(enumerator.Current, value))
            {
                return true;
            }
        }

        return false;
    }
}
