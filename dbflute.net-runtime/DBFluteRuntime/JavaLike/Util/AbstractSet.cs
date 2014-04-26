using System;
using System.Collections.Generic;

namespace DBFluteRuntime.JavaLike.Util
{
    // TODO 未実装
    public abstract class AbstractSet<E> : Set<E>
    {
        public int size()
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public bool contains(object o)
        {
            throw new NotImplementedException();
        }

        public object[] toArray()
        {
            throw new NotImplementedException();
        }

        public object[] toArray(object[] a)
        {
            throw new NotImplementedException();
        }

        public bool add(E e)
        {
            throw new NotImplementedException();
        }

        public bool remove(object o)
        {
            throw new NotImplementedException();
        }

        public bool containsAll(Collection<object> c)
        {
            throw new NotImplementedException();
        }

        public bool addAll<T>(Collection<T> c) where T : E
        {
            throw new NotImplementedException();
        }

        public bool removeAll(Collection<object> c)
        {
            throw new NotImplementedException();
        }

        public bool retainAll(Collection<object> c)
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public Iterator<E> iterator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<E> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
