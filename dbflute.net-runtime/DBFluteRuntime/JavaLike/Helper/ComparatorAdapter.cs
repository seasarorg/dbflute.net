using DBFluteRuntime.JavaLike.Util;
using System;

namespace DBFluteRuntime.JavaLike.Helper
{
    /// <summary>
    /// [Java]Comparatorと[C#]IComparerを繋ぐアダプタクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ComparatorAdapter<T> : System.Collections.Generic.IComparer<T>
    {
        private readonly Comparator<T> _comparator;

        public ComparatorAdapter(Comparator<T> comparator)
        {
            _comparator = comparator;
        }

        public int Compare(T x, T y)
        {
            return _comparator.compare(x, y);
        }
    }
}
