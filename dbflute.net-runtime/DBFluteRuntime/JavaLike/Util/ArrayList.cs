using DBFluteRuntime.JavaLike.Lang;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBFluteRuntime.JavaLike.Util
{
    /// <summary>
    /// Java ArrayListクラス
    /// </summary>
    /// <typeparam name="ELEMENT"></typeparam>
    [Serializable]
    public class ArrayList<ELEMENT> : List<ELEMENT>, NgList
    {
        IList<ELEMENT> _res = new System.Collections.Generic.List<ELEMENT>();

        public ArrayList()
        {
        }

        public ArrayList(Collection<ELEMENT> col)
        {
            foreach (ELEMENT element in col)
            {
                add(element);
            }
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
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{");
            int index = 0;
            foreach (ELEMENT element in this)
            {
                if (index > 0) { sb.Append(", "); }
                sb.Append(element);
                ++index;
            }
            sb.Append("}");
            return sb.toString();
        }
    }
}
