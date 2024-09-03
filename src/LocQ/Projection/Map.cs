using System.Collections;

public static class MapExtension
{
    public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source,
                                                              Func<TSource, TResult> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<TResult> MapManual<TSource, TResult>(this IEnumerable<TSource> source,
                                                              Func<TSource, TResult> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);

        return new MapEnumerable<TSource, TResult>(source, selector);
    }

    private class MapEnumerable<TSource, TResult> : IEnumerable<TResult>
    {
        private IEnumerable<TSource> _source;
        private Func<TSource, TResult> _selector;

        public MapEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this._source = source;
            this._selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new MapEnumerator<TSource, TResult>(_source, _selector);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private class MapEnumerator<TSource, TResult> : IEnumerator<TResult>
    {
        private IEnumerable<TSource> _source;
        private Func<TSource, TResult> _selector;
        private TResult _current = default!;
        private IEnumerator<TSource> _enumerator;
        private int _state = 1;

        public MapEnumerator(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this._source = source;
            this._selector = selector;
        }

        public TResult Current => _current;

        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            switch (_state)
            {
                case 1:
                    _enumerator = _source.GetEnumerator();
                    _state = 2;
                    goto case 2;
                case 2:
                    if(_enumerator.MoveNext())
                    {
                        _current = _selector(_enumerator.Current);
                        return true;
                    }
                    return false;
            }

            Dispose();
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            _enumerator?.Dispose();
            _state = -1;
        }

    }
}

