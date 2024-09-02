using System.Collections;

public static class FilterExtension
{
    public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TSource> FilterManual<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        if(source is IList<TSource> list)
        {
            return new FilterManualListEnumerable<TSource>(list, predicate);
        }
        

        return new FilterManualEnumerable<TSource>(source, predicate);
    }

    private sealed class FilterManualEnumerable<TSource> : IEnumerable<TSource>
    {
        private IEnumerable<TSource> _source;
        private Func<TSource, bool> _predicate;

        public FilterManualEnumerable(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            this._source = source;
            this._predicate = predicate;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return new FilterManualEnumerator<TSource>(_source, _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private sealed class FilterManualEnumerator<TSource> : IEnumerator<TSource>
    {
        private IEnumerable<TSource> _source;
        private Func<TSource, bool> _predicate;
        private TSource _current = default!;
        private IEnumerator<TSource> _sourceEnumerator;
        private int _state = 0;

        public FilterManualEnumerator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            this._source = source;
            this._predicate = predicate;
        }

        public TSource Current => _current;

        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            if (_state == 0)
            {
                _sourceEnumerator = _source.GetEnumerator();
                _state = 1;
            }

            while (_sourceEnumerator.MoveNext())
            {
                if (_predicate(_sourceEnumerator.Current))
                {
                    _current = _sourceEnumerator.Current;
                    return true;
                }
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
            _sourceEnumerator.Dispose();
        }

    }

    private sealed class FilterManualListEnumerable<TSource> : IEnumerable<TSource>
    {
        private IList<TSource> _source;
        private Func<TSource, bool> _predicate;

        public FilterManualListEnumerable(IList<TSource> source, Func<TSource, bool> predicate)
        {
            this._source = source;
            this._predicate = predicate;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return new FilterManualListEnumerator<TSource>(_source, _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private sealed class FilterManualListEnumerator<TSource> : IEnumerator<TSource>
    {
        private IList<TSource> _source;
        private Func<TSource, bool> _predicate;
        private TSource _current = default!;
        private int _state = 0;
        private int _index = 0;

        public FilterManualListEnumerator(IList<TSource> source, Func<TSource, bool> predicate)
        {
            this._source = source;
            this._predicate = predicate;
        }

        public TSource Current => _current;

        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            if (_state == 0)
            {
                _index = 0;
                _state = 1;
            }

            while(_index < _source.Count)
            {
                if(_predicate(_source[_index]))
                {
                    _current = _source[_index];
                    _index++;
                    return true;
                }
                _index++;
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
            // Invalidate the enumerator.
            _index = -1;
            _state = -1;
        }

    }
}

