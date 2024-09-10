using System.Collections;

public static class LimitExtension
{
    public static IEnumerable<T> Limit<T>(this IEnumerable<T> source, int count)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(count);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        return new LimitEnumerable<T>(source, count);
    }
    private class LimitEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        private IEnumerable<T> _source;
        private int _count;
        private int _state = 0;
        private T _current;
        private IEnumerator<T> _sourceEnumerator = null!;
        private int _takeCount = 0;

        public LimitEnumerable(IEnumerable<T> source, int count)
        {
            this._source = source;
            this._count = count;
        }

        public void Dispose()
        {
            _state = -1;
            _sourceEnumerator?.Dispose();
        }

        public bool MoveNext()
        {
            if (_state == 0)
            {
                _sourceEnumerator = _source.GetEnumerator();
                _state++;
            }

            while(_sourceEnumerator.MoveNext())
            {
                if(_takeCount >= _count)
                    break;

                _current = _sourceEnumerator.Current;
                _takeCount++;
                return true;
            }

            Dispose();
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T Current => _current;

        object IEnumerator.Current => Current!;

    }
}

