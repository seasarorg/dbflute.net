using System;
using System.Collections.Generic;
using System.Text;

namespace DBFluteRuntime.JavaLike.Util
{
    /**
     * This class provides a skeletal implementation of the <tt>Collection</tt>
     * interface, to minimize the effort required to implement this interface. <p>
     *
     * To implement an unmodifiable collection, the programmer needs only to
     * extend this class and provide implementations for the <tt>iterator</tt> and
     * <tt>size</tt> methods.  (The iterator returned by the <tt>iterator</tt>
     * method must implement <tt>hasNext</tt> and <tt>next</tt>.)<p>
     *
     * To implement a modifiable collection, the programmer must additionally
     * override this class's <tt>add</tt> method (which otherwise throws an
     * <tt>UnsupportedOperationException</tt>), and the iterator returned by the
     * <tt>iterator</tt> method must additionally implement its <tt>remove</tt>
     * method.<p>
     *
     * The programmer should generally provide a void (no argument) and
     * <tt>Collection</tt> constructor, as per the recommendation in the
     * <tt>Collection</tt> interface specification.<p>
     *
     * The documentation for each non-abstract method in this class describes its
     * implementation in detail.  Each of these methods may be overridden if
     * the collection being implemented admits a more efficient implementation.<p>
     *
     * This class is a member of the
     * <a href="{@docRoot}/../technotes/guides/collections/index.html">
     * Java Collections Framework</a>.
     *
     * @author  Josh Bloch
     * @author  Neal Gafter
     * @version %I%, %G%
     * @see Collection
     * @since 1.2
     */
    public abstract class AbstractCollection<E> : Collection<E>
    {
        /**
         * Sole constructor.  (For invocation by subclass constructors, typically
         * implicit.)
         */
        protected AbstractCollection() {
        }

        // Query Operations

        /**
         * Returns an iterator over the elements contained in this collection.
         *
         * @return an iterator over the elements contained in this collection
         */
        public abstract Iterator<E> iterator();

        public abstract int size();

        /**
         * {@inheritDoc}
         *
         * <p>This implementation returns <tt>size() == 0</tt>.
         */
        public virtual bool isEmpty() {
	        return size() == 0;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over the elements in the collection,
         * checking each element in turn for equality with the specified element.
         *
         * @throws ClassCastException   {@inheritDoc}
         * @throws NullPointerException {@inheritDoc}
         */
        public virtual bool contains(Object o) {
	        Iterator<E> e = iterator();
	        if (o == null) 
            {
	            while (e.hasNext())
                {
		            if (e.next()==null)
                    {
		                return true;
                    }
                }
	        } 
            else 
            {
	            while (e.hasNext())
                {
		            if (o.Equals(e.next()))
                    {
		                return true;
                    }
                }
	        }
	        return false;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation returns an array containing all the elements
         * returned by this collection's iterator, in the same order, stored in
         * consecutive elements of the array, starting with index {@code 0}.
         * The length of the returned array is equal to the number of elements
         * returned by the iterator, even if the size of this collection changes
         * during iteration, as might happen if the collection permits
         * concurrent modification during iteration.  The {@code size} method is
         * called only as an optimization hint; the correct result is returned
         * even if the iterator returns a different number of elements.
         *
         * <p>This method is equivalent to:
         *
         *  <pre> {@code
         * List<E> list = new ArrayList<E>(size());
         * for (E e : this)
         *     list.add(e);
         * return list.toArray();
         * }</pre>
         */
        public virtual Object[] toArray() {
            // Estimate size of array; be prepared to see more or fewer elements
            Object[] r = new Object[size()];
            Iterator<E> it = iterator();
            for (int i = 0; i < r.Length; i++)
            {
                if (!it.hasNext())	// fewer elements than expected
                    return Arrays.copyOf(r, i);
                r[i] = it.next();
            }
            return it.hasNext() ? finishToArray(r, (Iterator<object>)it) : r;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation returns an array containing all the elements
         * returned by this collection's iterator in the same order, stored in
         * consecutive elements of the array, starting with index {@code 0}.
         * If the number of elements returned by the iterator is too large to
         * fit into the specified array, then the elements are returned in a
         * newly allocated array with length equal to the number of elements
         * returned by the iterator, even if the size of this collection
         * changes during iteration, as might happen if the collection permits
         * concurrent modification during iteration.  The {@code size} method is
         * called only as an optimization hint; the correct result is returned
         * even if the iterator returns a different number of elements.
         *
         * <p>This method is equivalent to:
         *
         *  <pre> {@code
         * List<E> list = new ArrayList<E>(size());
         * for (E e : this)
         *     list.add(e);
         * return list.toArray(a);
         * }</pre>
         *
         * @throws ArrayStoreException  {@inheritDoc}
         * @throws NullPointerException {@inheritDoc}
         */
        public virtual T[] toArray<T>(T[] a) where T : new()
        {
            // Estimate size of array; be prepared to see more or fewer elements
            int size = this.size();
            // このコレクションと引数配列のサイズが大きい方に合わせて戻り値の配列を生成
            T[] r = a.Length >= size ? a : new T[size];
            Iterator<object> it = (Iterator<object>)iterator();

	        for (int i = 0; i < r.Length; i++) {
	            if (! it.hasNext()) { // fewer elements than expected
		            if (a != r)
		                return Arrays.copyOf(r, i);
                    r[i] = default(T) ; // null-terminate
		            return r;
	            }
	            r[i] = (T)it.next();
	        }
	        return it.hasNext() ? finishToArray(r, it) : r;
        }

        /**
         * Reallocates the array being used within toArray when the iterator
         * returned more elements than expected, and finishes filling it from
         * the iterator.
         *
         * @param r the array, replete with previously stored elements
         * @param it the in-progress iterator over this collection
         * @return array containing the elements in the given array, plus any
         *         further elements returned by the iterator, trimmed to size
         */
        private static T[] finishToArray<T>(T[] r, Iterator<object> it) {
	        int i = r.Length;
            while (it.hasNext()) 
            {
                int cap = r.Length;
                if (i == cap) 
                {
                    int newCap = ((cap / 2) + 1) * 3;
                    if (newCap <= cap) 
                    { // integer overflow
		                if (cap == int.MaxValue)
                        {
			                throw new OutOfMemoryException("Required array size too large");
                        }
		                newCap = int.MaxValue;
		            }
		            r = Arrays.copyOf(r, newCap);
	            }
	            r[i++] = (T)it.next();
            }
            // trim if overallocated
            return (i == r.Length) ? r : Arrays.copyOf(r, i);
        }

        // Modification Operations

        /**
         * {@inheritDoc}
         *
         * <p>This implementation always throws an
         * <tt>UnsupportedOperationException</tt>.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         * @throws IllegalArgumentException      {@inheritDoc}
         * @throws IllegalStateException         {@inheritDoc}
         */
        public virtual bool add(E e) {
            // javaでもUnsupportOperationExceptionをなげているのでそれに合わせる
	        throw new NotSupportedException();
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over the collection looking for the
         * specified element.  If it finds the element, it removes the element
         * from the collection using the iterator's remove method.
         *
         * <p>Note that this implementation throws an
         * <tt>UnsupportedOperationException</tt> if the iterator returned by this
         * collection's iterator method does not implement the <tt>remove</tt>
         * method and this collection contains the specified object.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         */
        public virtual bool remove(Object o) {
	        Iterator<E> e = iterator();
	        if (o == null) {
	            while (e.hasNext()) {
		            if (e.next()==null) {
		                e.remove();
		                return true;
		            }
	            }
	        } else {
	            while (e.hasNext()) {
		            if (o.Equals(e.next())) {
		                e.remove();
		                return true;
		            }
	            }
	        }
	        return false;
        }


        // Bulk Operations

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over the specified collection,
         * checking each element returned by the iterator in turn to see
         * if it's contained in this collection.  If all elements are so
         * contained <tt>true</tt> is returned, otherwise <tt>false</tt>.
         *
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         * @see #contains(Object)
         */
        public virtual bool containsAll(Collection<object> c) {
	        Iterator<object> e = c.iterator();
	        while (e.hasNext())
            {
	            if (!contains(e.next()))
                {
		            return false;
                }
            }
	        return true;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over the specified collection, and adds
         * each object returned by the iterator to this collection, in turn.
         *
         * <p>Note that this implementation will throw an
         * <tt>UnsupportedOperationException</tt> unless <tt>add</tt> is
         * overridden (assuming the specified collection is non-empty).
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         * @throws IllegalArgumentException      {@inheritDoc}
         * @throws IllegalStateException         {@inheritDoc}
         *
         * @see #add(Object)
         */
        public virtual bool addAll<T>(Collection<T> c) where T : E 
        {
	        bool modified = false;
	        Iterator<T> e = c.iterator();
	        while (e.hasNext()) 
            {
	            if (add(e.next()))
                {
		            modified = true;
                }
	        }
	        return modified;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over this collection, checking each
         * element returned by the iterator in turn to see if it's contained
         * in the specified collection.  If it's so contained, it's removed from
         * this collection with the iterator's <tt>remove</tt> method.
         *
         * <p>Note that this implementation will throw an
         * <tt>UnsupportedOperationException</tt> if the iterator returned by the
         * <tt>iterator</tt> method does not implement the <tt>remove</tt> method
         * and this collection contains one or more elements in common with the
         * specified collection.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         *
         * @see #remove(Object)
         * @see #contains(Object)
         */
        public virtual bool removeAll<T>(Collection<T> c) {
	        bool modified = false;
	        Iterator<E> e = iterator();
	        while (e.hasNext()) {
	            if (c.contains(e.next())) {
		            e.remove();
		            modified = true;
	            }
	        }
	        return modified;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over this collection, checking each
         * element returned by the iterator in turn to see if it's contained
         * in the specified collection.  If it's not so contained, it's removed
         * from this collection with the iterator's <tt>remove</tt> method.
         *
         * <p>Note that this implementation will throw an
         * <tt>UnsupportedOperationException</tt> if the iterator returned by the
         * <tt>iterator</tt> method does not implement the <tt>remove</tt> method
         * and this collection contains one or more elements not present in the
         * specified collection.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         *
         * @see #remove(Object)
         * @see #contains(Object)
         */
        public virtual bool retainAll<T>(Collection<T> c) {
	        bool modified = false;
	        Iterator<E> e = iterator();
	        while (e.hasNext()) {
	            if (!c.contains(e.next())) {
		            e.remove();
		            modified = true;
	            }
	        }
	        return modified;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation iterates over this collection, removing each
         * element using the <tt>Iterator.remove</tt> operation.  Most
         * implementations will probably choose to override this method for
         * efficiency.
         *
         * <p>Note that this implementation will throw an
         * <tt>UnsupportedOperationException</tt> if the iterator returned by this
         * collection's <tt>iterator</tt> method does not implement the
         * <tt>remove</tt> method and this collection is non-empty.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         */
        public virtual void clear() {
	        Iterator<E> e = iterator();
	        while (e.hasNext()) {
	            e.next();
	            e.remove();
	        }
        }


        //  String conversion

        /**
         * Returns a string representation of this collection.  The string
         * representation consists of a list of the collection's elements in the
         * order they are returned by its iterator, enclosed in square brackets
         * (<tt>"[]"</tt>).  Adjacent elements are separated by the characters
         * <tt>", "</tt> (comma and space).  Elements are converted to strings as
         * by {@link String#valueOf(Object)}.
         *
         * @return a string representation of this collection
         */
        public virtual String toString()
        {
            Iterator<E> i = iterator();
            if (!i.hasNext())
                return "[]";

            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            for (; ; )
            {
                E e = i.next();
                sb.Append(e.Equals(this) ? "(this Collection)" : e.ToString());
                if (!i.hasNext())
                {
                    return sb.Append(']').ToString();
                }
                sb.Append(", ");
            }
        }

        public virtual object[] toArray(object[] a)
        {
            throw new NotImplementedException();
        }

        public virtual bool removeAll(Collection<object> c)
        {
            throw new NotImplementedException();
        }

        public virtual bool retainAll(Collection<object> c)
        {
            throw new NotImplementedException();
        }

        public virtual int hashCode()
        {
            throw new NotImplementedException();
        }

        public abstract IEnumerator<E> GetEnumerator();


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
