using DBFlute.JavaLike.Helper;
using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]LinkedHashSetクラス
    /// </summary>
    /// <typeparam name="ELEMENT"></typeparam>
    [Serializable]
    public class LinkedHashSet<ELEMENT> : Set<ELEMENT>, NgSet
    {
        protected readonly IDictionary<ELEMENT, Object> _res;
        protected readonly List<ELEMENT> _seq;

        public LinkedHashSet()
        {
            _res = new Dictionary<ELEMENT, Object>();
            _seq = new ArrayList<ELEMENT>();
        }

        public LinkedHashSet(int size)
        {
            _res = new Dictionary<ELEMENT, Object>(size);
            _seq = new ArrayList<ELEMENT>(size);
        }

        public LinkedHashSet(Set<ELEMENT> res) : this(res.size())
        {
            foreach (var r in res)
            {
                _res.Add(r, r);
                _seq.Add(r);
            }
        }

        public ELEMENT get(int index)
        {
            return _seq.get(index);
        }

        public bool add(ELEMENT element)
        {
            if (_res.ContainsKey(element))
            {
                return false;
            }
            _res.Add(element, null);
            _seq.add(element);
            return true;
        }

        public bool addAll(ICollection<ELEMENT> elementList)
        {
            bool result = false;
            foreach (ELEMENT element in elementList)
            {
                if (add(element))
                {
                    result = true;
                }
            }
            return result;
        }

        public bool remove(ELEMENT element)
        {
            if (_res.ContainsKey(element))
            {
                _res.Remove(element);
                _seq.remove(element);
                return true;
            }
            return false;
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

        public bool contains(ELEMENT element)
        {
            return _res.ContainsKey(element);
        }

        public ICollection<ELEMENT> getCollection()
        {
            return _seq.getCollection();
        }

        public bool containsAsNg(Object element)
        {
            return contains((ELEMENT)element);
        }

        public bool addAsNg(Object element)
        {
            return add((ELEMENT)element);
        }

        public bool removeAsNg(Object element)
        {
            return remove((ELEMENT)element);
        }

        public System.Collections.ICollection getCollectionAsNg()
        {
            return (System.Collections.ICollection)getCollection();
        }

        public Iterator<ELEMENT> iterator()
        {
            return new MyEmumerator(this);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new MyEmumerator(this);
        }

        [System.Serializable]
        protected class MyEmumerator : System.Collections.IEnumerator, Iterator<ELEMENT>
        {
            protected LinkedHashSet<ELEMENT> _target;
            protected int _index = -1;
            public MyEmumerator(LinkedHashSet<ELEMENT> target)
            {
                _target = target;
            }
            public Object Current { get { return _target.get(_index); } }
            public bool MoveNext()
            {
                ++_index;
                return _target.size() > _index;
            }
            public void Reset()
            {
                _index = -1;
            }
            public bool hasNext()
            {
                return MoveNext();
            }
            public ELEMENT next()
            { // Not moving because hasNext() does it.
                if (_index == -1) { MoveNext(); } // For getting first element.
                return _target.get(_index);
            }
        }

        public override String ToString()
        {
            return StringHelper.collectionToString<ELEMENT>(this);
        }


        void Set<ELEMENT>.add(ELEMENT element)
        {
            throw new NotImplementedException();
        }


        public Set<ELEMENT> unmodifiableSet(Set<ELEMENT> element)
        {
            throw new NotImplementedException();
        }

        IEnumerator<ELEMENT> IEnumerable<ELEMENT>.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public void Add(ELEMENT item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ELEMENT item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ELEMENT[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(ELEMENT item)
        {
            throw new NotImplementedException();
        }
    }
}
