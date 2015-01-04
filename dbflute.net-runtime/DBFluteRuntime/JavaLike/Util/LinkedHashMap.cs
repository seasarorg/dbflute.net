using DBFlute.JavaLike.Helper;
using System;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]LinkedHashMapクラス
    /// </summary>
    [Serializable]
    public class LinkedHashMap<KEY, VALUE> : Map<KEY, VALUE>, NgMap
    {
        protected Map<KEY, VALUE> _res = new HashMap<KEY, VALUE>();
        protected LinkedHashSet<KEY> _seq = new LinkedHashSet<KEY>();

        public VALUE get(KEY key)
        {
            return _res.containsKey(key) ? _res.get(key) : default(VALUE);
        }

        public VALUE get(int index)
        {
            return _res.get(_seq.get(index));
        }

        public VALUE put(KEY key, VALUE value)
        {
            VALUE result = default(VALUE);
            if (_res.containsKey(key))
            {
                result = _res.get(key);
            }
            else
            {
                _seq.add(key);
            }
            _res.put(key, value);
            return result;
        }

        public VALUE remove(KEY key)
        {
            VALUE result = default(VALUE);
            if (_res.containsKey(key))
            {
                result = _res.get(key);
                _res.remove(key);
                _seq.remove(key);
            }
            return result;
        }

        public int size()
        {
            return _res.size();
        }

        public bool isEmpty()
        {
            return _res.isEmpty();
        }

        public void clear()
        {
            _res.clear();
        }

        public bool containsKey(KEY obj)
        {
            return _res.containsKey(obj);
        }

        public Set<KEY> keySet()
        {
            return _seq;
        }

        public Collection<VALUE> values()
        {
            List<VALUE> valueList = new ArrayList<VALUE>();
            foreach (KEY key in _seq.getCollection())
            {
                valueList.add(_res.get(key));
            }
            return valueList;
        }

        public Set<Entry<KEY, VALUE>> entrySet()
        {
            Set<Entry<KEY, VALUE>> entrySet = new LinkedHashSet<Entry<KEY, VALUE>>();
            Set<KEY> keyCol = _res.keySet();
            foreach (KEY key in keyCol)
            {
                entrySet.add(new Entry<KEY, VALUE>(key, _res.get(key)));
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
    }
}
