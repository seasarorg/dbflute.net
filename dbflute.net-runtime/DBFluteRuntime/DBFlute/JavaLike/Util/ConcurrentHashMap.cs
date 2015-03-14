using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]スレッドセーフなHashMap
    /// </summary>
    /// <typeparam name="KEY"></typeparam>
    /// <typeparam name="VALUE"></typeparam>
    public class ConcurrentHashMap<KEY, VALUE> : HashMap<KEY, VALUE>
    {
        public ConcurrentHashMap() : base() { }
        public ConcurrentHashMap(int size) : base(size) { }
        public ConcurrentHashMap(Map<KEY, VALUE> res) : base(res) { }

        protected override IDictionary<KEY, VALUE> createDictionary()
        {
            return new System.Collections.Concurrent.ConcurrentDictionary<KEY, VALUE>();
        }

        protected override IDictionary<KEY, VALUE> createDictionary(int size)
        {
            // ConcurrentMapにsizeのみを渡すコンストラクタはない
            return createDictionary();
        }
    }
}
