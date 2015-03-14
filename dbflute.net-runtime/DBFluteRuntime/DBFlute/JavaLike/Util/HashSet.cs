using DBFlute.JavaLike.Helper;
using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]HashSetクラス
    /// </summary>
    /// <typeparam name="ELEMENT"></typeparam>
    [Serializable]
    public class HashSet<ELEMENT> : Set<ELEMENT>, NgSet
    {
        protected readonly IDictionary<ELEMENT, Object> _res;

        public HashSet()
        {
            _res = new Dictionary<ELEMENT, Object>();
        }

        public HashSet(Set<ELEMENT> elements)
        {
            var res = new Dictionary<ELEMENT, Object>(elements.size());
            foreach(var element in elements)
            {
                res.Add(element, element);
            }
            _res = res;
        }

        public HashSet(int size)
        {
            _res = new Dictionary<ELEMENT, Object>(size);
        }

        public bool add(ELEMENT element)
        {
            if (_res.ContainsKey(element))
            {
                return false;
            }
            _res.Add(element, null);
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
            return _res.Keys;
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
            protected IEnumerator<ELEMENT> _target;
            protected int _index;
            public MyEmumerator(HashSet<ELEMENT> target)
            {
                _target = target.getCollection().GetEnumerator();
            }
            public Object Current { get { return _target.Current; } }
            public bool MoveNext()
            {
                return _target.MoveNext();
            }
            public void Reset()
            {
                _target.Reset();
            }
            public bool hasNext()
            {
                return MoveNext();
            }
            public ELEMENT next()
            { // Not moving because hasNext() does it.
                return _target.Current;
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
