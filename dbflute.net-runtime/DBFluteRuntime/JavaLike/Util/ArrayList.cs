using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFluteRuntime.JavaLike.Util
{
    /**
     * Resizable-array implementation of the <tt>List</tt> interface.  Implements
     * all optional list operations, and permits all elements, including
     * <tt>null</tt>.  In addition to implementing the <tt>List</tt> interface,
     * this class provides methods to manipulate the size of the array that is
     * used internally to store the list.  (This class is roughly equivalent to
     * <tt>Vector</tt>, except that it is unsynchronized.)<p>
     *
     * The <tt>size</tt>, <tt>isEmpty</tt>, <tt>get</tt>, <tt>set</tt>,
     * <tt>iterator</tt>, and <tt>listIterator</tt> operations run in constant
     * time.  The <tt>add</tt> operation runs in <i>amortized constant time</i>,
     * that is, adding n elements requires O(n) time.  All of the other operations
     * run in linear time (roughly speaking).  The constant factor is low compared
     * to that for the <tt>LinkedList</tt> implementation.<p>
     *
     * Each <tt>ArrayList</tt> instance has a <i>capacity</i>.  The capacity is
     * the size of the array used to store the elements in the list.  It is always
     * at least as large as the list size.  As elements are added to an ArrayList,
     * its capacity grows automatically.  The details of the growth policy are not
     * specified beyond the fact that adding an element has constant amortized
     * time cost.<p>
     *
     * An application can increase the capacity of an <tt>ArrayList</tt> instance
     * before adding a large number of elements using the <tt>ensureCapacity</tt>
     * operation.  This may reduce the amount of incremental reallocation.
     *
     * <p><strong>Note that this implementation is not synchronized.</strong>
     * If multiple threads access an <tt>ArrayList</tt> instance concurrently,
     * and at least one of the threads modifies the list structurally, it
     * <i>must</i> be synchronized externally.  (A structural modification is
     * any operation that adds or deletes one or more elements, or explicitly
     * resizes the backing array; merely setting the value of an element is not
     * a structural modification.)  This is typically accomplished by
     * synchronizing on some object that naturally encapsulates the list.
     *
     * If no such object exists, the list should be "wrapped" using the
     * {@link Collections#synchronizedList Collections.synchronizedList}
     * method.  This is best done at creation time, to prevent accidental
     * unsynchronized access to the list:<pre>
     *   List list = Collections.synchronizedList(new ArrayList(...));</pre>
     *
     * <p>The iterators returned by this class's <tt>iterator</tt> and
     * <tt>listIterator</tt> methods are <i>fail-fast</i>: if the list is
     * structurally modified at any time after the iterator is created, in any way
     * except through the iterator's own <tt>remove</tt> or <tt>add</tt> methods,
     * the iterator will throw a {@link ConcurrentModificationException}.  Thus, in
     * the face of concurrent modification, the iterator fails quickly and cleanly,
     * rather than risking arbitrary, non-deterministic behavior at an undetermined
     * time in the future.<p>
     *
     * Note that the fail-fast behavior of an iterator cannot be guaranteed
     * as it is, generally speaking, impossible to make any hard guarantees in the
     * presence of unsynchronized concurrent modification.  Fail-fast iterators
     * throw <tt>ConcurrentModificationException</tt> on a best-effort basis.
     * Therefore, it would be wrong to write a program that depended on this
     * exception for its correctness: <i>the fail-fast behavior of iterators
     * should be used only to detect bugs.</i><p>
     *
     * This class is a member of the
     * <a href="{@docRoot}/../technotes/guides/collections/index.html">
     * Java Collections Framework</a>.
     *
     * @author  Josh Bloch
     * @author  Neal Gafter
     * @version %I%, %G%
     * @see	    Collection
     * @see	    List
     * @see	    LinkedList
     * @see	    Vector
     * @since   1.2
     */
    public class ArrayList<E> : List<E>, ICloneable
    {
        // #pending
        // AbstractList<E>, RandomAccess, Serializableの実装は保留
        /// <summary>
        /// C#における「ArrayList」
        /// </summary>
        private readonly System.Collections.Generic.List<E> _csList = new System.Collections.Generic.List<E>();

        public bool addAll<T>(int index, Collection<T> c) where T : E
        {
            throw new NotImplementedException();
        }

        public E get(int index)
        {
            return _csList[index];
        }

        public E set(int index, E element)
        {
            throw new NotImplementedException();
        }

        public void add(int index, E element)
        {
            throw new NotImplementedException();
        }

        public E remove(int index)
        {
            E removedItem = _csList[index];
            _csList.RemoveAt(index);
            return removedItem;
        }

        public int indexOf(object o)
        {
            return _csList.IndexOf((E)o);
        }

        public int lastIndexOf(object o)
        {
            throw new NotImplementedException();
        }

        public ListIterator<E> listIterator()
        {
            return new ListIteratorImpl<E>(_csList);
        }

        public ListIterator<E> listIterator(int index)
        {
            throw new NotImplementedException();
        }

        public List<E> subList(int fromIndex, int toIndex)
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            return _csList.Count();
        }

        public bool isEmpty()
        {
            return (_csList.Count() == 0);
        }

        public bool contains(object o)
        {
            return _csList.Contains((E)o);
        }

        public bool containsAll(Collection<object> c)
        {
            foreach(object cItem in c)
            {
                if (_csList.Contains((E)cItem))
                {
                    return true;
                }
            }
            return false;
        }

        public object[] toArray()
        {
            object[] ret = new object[_csList.Count()];
            for (int i = 0; i < _csList.Count(); i++ )
            {
                ret[i] = _csList[i];
            }
            return ret;
        }

        public E[] toArray(E[] a)
        {
            return _csList.ToArray();
        }

        public object[] toArray(object[] source)
        {
            // TODO:[java]ArrayListの実装の意図がよくわからないため保留
            throw new NotImplementedException();
        }

        public bool add(E e)
        {
            _csList.Add(e);
            // JavaのArrayListもaddメソッドは固定値でtrueを返している
            return true;
        }

        public bool remove(object o)
        {
            return _csList.Remove((E)o);
        }

        public bool addAll<T>(Collection<T> c) where T : E
        {
            try
            {
                _csList.AddRange((Collection<E>)c);
                return true;
            }
            catch (InvalidCastException)
            {
                // TODO 例外処理
                return false;
            }
        }

        public bool removeAll(Collection<object> c)
        {
            foreach(object cItem in c)
            {
                if(!_csList.Remove((E)cItem))
                {
                    return false;
                }
            }
            return true;
        }

        public bool retainAll(Collection<object> c)
        {
            try
            {
                IEnumerable<E> retainItems = _csList.Where(e => c.contains(e));
                _csList.Clear();
                _csList.AddRange(retainItems);
                return true;
            } 
            catch(Exception)
            {
                return false;
            }
        }

        public void clear()
        {
            _csList.Clear();
        }

        public bool equals(object o)
        {
            return _csList.Equals(o);
        }

        public int hashCode()
        {
            return _csList.GetHashCode();
        }

        public Iterator<E> iterator()
        {
            return new IteratorImpl<E>(_csList);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<E> GetEnumerator()
        {
            return _csList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _csList.GetEnumerator();
        }

        // ======================================================================================
        //                                                                           Inner class
        //                                                                          =============
        /// <summary>
        /// GetIterator用実装クラス
        /// </summary>
        /// <typeparam name="E"></typeparam>
        private class IteratorImpl<T> : Iterator<T>
        {
            private readonly System.Collections.Generic.List<T> _csList;
            private int _nextIndex = 0;

            public IteratorImpl(System.Collections.Generic.List<T> csList)
            {
                _csList = csList;
            }

            public bool hasNext()
            {
                return _nextIndex < _csList.Count();
            }

            public T next()
            {
                T ret = _csList[_nextIndex];
                _nextIndex++;
                return ret;
            }

            public void remove()
            {
                _csList.RemoveAt(_nextIndex);
            }
        }

        /// <summary>
        /// listIterator用実装クラス
        /// </summary>
        /// <typeparam name="E"></typeparam>
        private class ListIteratorImpl<LI> : ListIterator<LI>
        {
            private readonly System.Collections.Generic.List<LI> _csList;
            private int _index = 0;

            public ListIteratorImpl(System.Collections.Generic.List<LI> csList)
            {
                _csList = csList;
            }

            public ListIteratorImpl(System.Collections.Generic.List<LI> csList, int index)
            {
                _csList = csList;
                _index = index;
            }  

            public bool hasPrevious()
            {
                return _index > 0;
            }

            public LI previous()
            {
                _index--;
                return _csList[_index];
            }

            public int nextIndex()
            {
                return (_index + 1);
            }

            public int previousIndex()
            {
                return (_index - 1);
            }

            public void set(LI e)
            {
                _csList[_index] = e;
            }

            public void add(LI e)
            {
                _csList.Add(e);
            }

            public bool hasNext()
            {
                return _csList.Count() > (_index + 1);
            }

            public LI next()
            {
                _index++;
                return _csList[_index];
            }

            public void remove()
            {
                _csList.RemoveAt(_index);
                if (_index != 0)
                {
                    _index--;
                }
            }
        }
    }
}
