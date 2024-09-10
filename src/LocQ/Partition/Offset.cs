using System.Collections;

public static class OffsetExtension
{
    public static IEnumerable<T> Offset<T>(this IEnumerable<T> source, int count)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(count);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        return new OffSetEnumerable<T>(source, count);
    }

    private class OffSetEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        private IEnumerable<T> source;
        private int count;

        private T _current = default!;
        private IEnumerator<T>? sourceEnumerator = null;
        private int _state = 0;
        private int _count = 0;

        public OffSetEnumerable(IEnumerable<T> source, int count)
        {
            this.source = source;
            this.count = count;
        }

        public T Current => _current;

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
            sourceEnumerator?.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            switch (_state)
            {
                case 0:
                    sourceEnumerator = source.GetEnumerator();
                    _state++;
                    goto default;
                default:
                    while(sourceEnumerator.MoveNext())
                    {
                        if (_count < count)
                        {
                            _count++;
                            continue;
                        }
                        else
                        {
                            _current = sourceEnumerator.Current;
                            return true;
                        }
                    }
                    break;
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
