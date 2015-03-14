using DBFlute.JavaLike.Helper;
using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// Java ArrayListクラス
    /// </summary>
    /// <typeparam name="ELEMENT"></typeparam>
    [Serializable]
    public class ArrayList<ELEMENT> : List<ELEMENT>, NgList
    {
        private readonly IList<ELEMENT> _res;

        public ArrayList()
        {
            _res = new System.Collections.Generic.List<ELEMENT>();
        }

        public ArrayList(ICollection<ELEMENT> col)
        {
            _res = new System.Collections.Generic.List<ELEMENT>();
            foreach (ELEMENT element in col)
            {
                add(element);
            }
        }

        public ArrayList(int size)
        {
            _res = new System.Collections.Generic.List<ELEMENT>(size);
        }

        public bool add(ELEMENT element)
        {
            _res.Add(element);
            return true;
        }

        public bool addAll(Collection<ELEMENT> elementList)
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

        public ELEMENT get(int index)
        {
            return _res[index];
        }

        public ELEMENT set(int index, ELEMENT element)
        {
            ELEMENT result = _res[index];
            _res[index] = element;
            return result;
        }

        public ELEMENT remove(int index)
        {
            ELEMENT result = _res[index];
            _res.Remove(result);
            return result;
        }

        public bool remove(ELEMENT element)
        {
            return _res.Remove(element);
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

        // merely copied list so not related to original list
        public List<ELEMENT> subList(int fromIndex, int toIndex)
        {
            List<ELEMENT> resultList = new ArrayList<ELEMENT>();
            for (int i = fromIndex; i < toIndex; i++)
            {
                resultList.add(get(i));
            }
            return resultList;
        }

        public IList<ELEMENT> getList()
        {
            return _res;
        }

        public ICollection<ELEMENT> getCollection()
        {
            return _res;
        }

        public Object getAsNg(int index)
        {
            return get(index);
        }

        public System.Collections.IList getListAsNg()
        {
            return (System.Collections.IList)getList();
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
            public MyEmumerator(ArrayList<ELEMENT> target)
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


        public Set<ELEMENT> unmodifiableSet(Set<ELEMENT> element)
        {
            throw new NotImplementedException();
        }


        public bool addAll(ICollection<ELEMENT> elements)
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

        IEnumerator<ELEMENT> IEnumerable<ELEMENT>.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public void removeAll()
        {
            throw new NotImplementedException();
        }


        public void removeAll(ICollection<ELEMENT> elements)
        {
            throw new NotImplementedException();
        }


        public int indexOf(ELEMENT element)
        {
            throw new NotImplementedException();
        }
    }
}
