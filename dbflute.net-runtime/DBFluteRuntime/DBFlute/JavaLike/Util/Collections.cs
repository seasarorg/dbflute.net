using System;

namespace DBFlute.JavaLike.Util
{
    // #pending 未実装
    /// <summary>
    /// [Java]Collections
    /// </summary>
    public class Collections
    {
        public static Set<T> synchronizedSet<T>(Set<T> s)
        {
            throw new NotSupportedException();
        }

        public static Set<T> unmodifiableSet<T>(Set<T> s)
        {
            throw new NotSupportedException();
        }

        public static List<T> emptyList<T>()
        {
            return new ArrayList<T>();
        }

        public static Set<T> emptySet<T>()
        {
            return new HashSet<T>();
        }

        public static Map<K, V> emptyMap<K, V>()
        {
            return new HashMap<K, V>();
        }

        public static void sort<T>(List<T> unorderedList, Comparater<T> comp)
        {
            throw new NotSupportedException();
        }
    }
}
