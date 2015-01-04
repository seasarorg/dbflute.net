using System;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]Entryクラス
    /// </summary>
    /// <typeparam name="KEY"></typeparam>
    /// <typeparam name="VALUE"></typeparam>
    [Serializable]
    public class Entry<KEY, VALUE>
    {
        protected KEY _key;
        protected VALUE _value;
        public override String ToString()
        {
            return _key + "=" + _value;
        }

        public Entry(KEY key, VALUE value)
        {
            _key = key;
            _value = value;
        }

        public KEY getKey()
        {
            return _key;
        }

        public VALUE getValue()
        {
            return _value;
        }
    }
}
