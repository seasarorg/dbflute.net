using DBFlute.JavaLike.Helper;
using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]HashMapクラス
    /// </summary>
    [Serializable]
    public class HashMap<KEY, VALUE> : Map<KEY, VALUE>, NgMap
    {
        protected readonly IDictionary<KEY, VALUE> _res;
        
        public HashMap()
        {
            _res = createDictionary();
        }

        public HashMap(int size)
        {
            _res = createDictionary(size);
        }

        public HashMap(Map<KEY, VALUE> res)
        {
            _res = createDictionary();
            foreach (var key in res.keySet())
            {
                _res.Add(key, res.get(key));
            }
        }

        public VALUE get(KEY key)
        {
            return _res.ContainsKey(key) ? _res[key] : default(VALUE);
        }

        public VALUE put(KEY key, VALUE value)
        {
            VALUE result = default(VALUE);
            if (_res.ContainsKey(key))
            {
                result = _res[key];
            }
            _res[key] = value;
            return result;
        }

        public VALUE remove(KEY key)
        {
            VALUE result = default(VALUE);
            if (_res.ContainsKey(key))
            {
                result = _res[key];
                _res.Remove(key);
            }
            return result;
        }

        public int size()
        {
            return _res.Count;
        }

        public bool isEmpty()
        {
            return _res.Count == 0;
        }

        public void clear()
        {
            _res.Clear();
        }

        public bool containsKey(KEY key)
        {
            return _res.ContainsKey(key);
        }

        public Set<KEY> keySet()
        {
            Set<KEY> keySet = new LinkedHashSet<KEY>();
            ICollection<KEY> keyCol = _res.Keys;
            foreach (KEY key in keyCol)
            {
                keySet.add(key);
            }
            return keySet;
        }

        public Collection<VALUE> values()
        {
            return new Collection<VALUE>(_res.Values);
        }

        public Set<Entry<KEY, VALUE>> entrySet()
        {
            Set<Entry<KEY, VALUE>> entrySet = new LinkedHashSet<Entry<KEY, VALUE>>();
            ICollection<KEY> keyCol = _res.Keys;
            foreach (KEY key in keyCol)
            {
                entrySet.add(new Entry<KEY, VALUE>(key, _res[key]));
            }
            return entrySet;
        }

        public Object getAsNg(Object key)
        {
            return get((KEY)key);
        }

        public Object putAsNg(Object key, Object value)
        {
            return put((KEY)key, (VALUE)value);
        }

        public Object removeAsNg(Object key)
        {
            return remove((KEY)key);
        }

        public bool containsKeyAsNg(Object key)
        {
            return containsKey((KEY)key);
        }

        public override String ToString()
        {
            return StringHelper.collectionToString(entrySet());
        }

        protected virtual IDictionary<KEY, VALUE> createDictionary()
        {
            return new Dictionary<KEY, VALUE>();
        }

        protected virtual IDictionary<KEY, VALUE> createDictionary(int size)
        {
            return new Dictionary<KEY, VALUE>(size);
        }
    }
}
