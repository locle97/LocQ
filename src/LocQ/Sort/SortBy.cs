using System.Collections;

public static class SortByExtension
{
    public static IEnumerable<TSource> SortBy<TSource, TSelector>(this IEnumerable<TSource> source,
                                                                    Func<TSource, TSelector> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);

        if (source is TSource[] array)
            return new SortByArray<TSource,TSelector>(array, selector);

        return new SortByEnumerable<TSource, TSelector>(source, selector);
    }

    private class SortByArray<TSource, TSelector> : IEnumerable<TSource>, IEnumerator<TSource>
    {
        private TSource[] _source;
        private TSource[] _buffer;
        private Func<TSource, TSelector> _selector;
        private TSource _current = default!;
        private int _state = 0;
        private readonly IComparer<TSelector> _comparer = Comparer<TSelector>.Default;

        public SortByArray(TSource[] source, Func<TSource, TSelector> selector)
        {
            this._source = source;
            this._selector = selector;
        }

        public TSource Current => _current;

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
            _state = 0;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_state == 0)
            {
                _buffer = (TSource[])_source.Clone();
                Array.Sort(_buffer, (a, b) =>
                {
                    return _comparer.Compare(_selector(a), _selector(b));
                });
                _state++;
            }

            int index = _state - 1;
            if (index < _buffer.Length)
            {
                _current = _buffer[index];
                _state++;
                return true;
            }

            Dispose();
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private class SortByEnumerable<TSource, TSelector> : IEnumerable<TSource>, IEnumerator<TSource>
    {
        private IEnumerable<TSource> _source;
        private Func<TSource, TSelector> _selector;
        private TSource _current = default!;
        private TSource[] _buffer;
        private int _state = 0;
        private readonly IComparer<TSelector> _comparer = Comparer<TSelector>.Default;

        public SortByEnumerable(IEnumerable<TSource> source, Func<TSource, TSelector> selector)
        {
            this._source = source;
            this._selector = selector;
        }

        public TSource Current => _current;

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
            _state = 0;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_state == 0)
            {
                _buffer = this._source.ToArray();
                Array.Sort(_buffer, (a, b) =>
                {
                    return _comparer.Compare(_selector(a), _selector(b));
                });
                _state++;
            }

            int index = _state - 1;
            if (index < _buffer.Length)
            {
                _current = _buffer[index];
                _state++;
                return true;
            }

            Dispose();
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
