using DBFluteRuntime.JavaLike.Lang;
using System;
using System.Collections.Generic;

namespace DBFluteRuntime.JavaLike.Util
{
    /**
     * This class provides a skeletal implementation of the {@link List}
     * interface to minimize the effort required to implement this interface
     * backed by a "random access" data store (such as an array).  For sequential
     * access data (such as a linked list), {@link AbstractSequentialList} should
     * be used in preference to this class.
     *
     * <p>To implement an unmodifiable list, the programmer needs only to extend
     * this class and provide implementations for the {@link #get(int)} and
     * {@link List#size() size()} methods.
     *
     * <p>To implement a modifiable list, the programmer must additionally
     * override the {@link #set(int, Object) set(int, E)} method (which otherwise
     * throws an {@code UnsupportedOperationException}).  If the list is
     * variable-size the programmer must additionally override the
     * {@link #add(int, Object) add(int, E)} and {@link #remove(int)} methods.
     *
     * <p>The programmer should generally provide a void (no argument) and collection
     * constructor, as per the recommendation in the {@link Collection} interface
     * specification.
     *
     * <p>Unlike the other abstract collection implementations, the programmer does
     * <i>not</i> have to provide an iterator implementation; the iterator and
     * list iterator are implemented by this class, on top of the "random access"
     * methods:
     * {@link #get(int)},
     * {@link #set(int, Object) set(int, E)},
     * {@link #add(int, Object) add(int, E)} and
     * {@link #remove(int)}.
     *
     * <p>The documentation for each non-abstract method in this class describes its
     * implementation in detail.  Each of these methods may be overridden if the
     * collection being implemented admits a more efficient implementation.
     *
     * <p>This class is a member of the
     * <a href="{@docRoot}/../technotes/guides/collections/index.html">
     * Java Collections Framework</a>.
     *
     * @author  Josh Bloch
     * @author  Neal Gafter
     * @version %I%, %G%
     * @since 1.2
     */
    public abstract class AbstractList<E> : AbstractCollection<E>, JavaLike.Util.List<E>
    {
        /**
         * Sole constructor.  (For invocation by subclass constructors, typically
         * implicit.)
         */
        protected AbstractList() {
        }

        /**
         * Appends the specified element to the end of this list (optional
         * operation).
         *
         * <p>Lists that support this operation may place limitations on what
         * elements may be added to this list.  In particular, some
         * lists will refuse to add null elements, and others will impose
         * restrictions on the type of elements that may be added.  List
         * classes should clearly specify in their documentation any restrictions
         * on what elements may be added.
         *
         * <p>This implementation calls {@code add(size(), e)}.
         *
         * <p>Note that this implementation throws an
         * {@code UnsupportedOperationException} unless
         * {@link #add(int, Object) add(int, E)} is overridden.
         *
         * @param e element to be appended to this list
         * @return {@code true} (as specified by {@link Collection#add})
         * @throws UnsupportedOperationException if the {@code add} operation
         *         is not supported by this list
         * @throws ClassCastException if the class of the specified element
         *         prevents it from being added to this list
         * @throws NullPointerException if the specified element is null and this
         *         list does not permit null elements
         * @throws IllegalArgumentException if some property of this element
         *         prevents it from being added to this list
         */
        public override bool add(E e) {
	        add(size(), e);
	        return true;
        }

        /**
         * {@inheritDoc}
         *
         * @throws IndexOutOfRangeException {@inheritDoc}
         */
        public abstract E get(int index);

        /**
         * {@inheritDoc}
         *
         * <p>This implementation always throws an
         * {@code UnsupportedOperationException}.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         * @throws IllegalArgumentException      {@inheritDoc}
         * @throws IndexOutOfRangeException     {@inheritDoc}
         */
        public virtual E set(int index, E element) {
            throw new NotSupportedException();
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation always throws an
         * {@code UnsupportedOperationException}.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         * @throws IllegalArgumentException      {@inheritDoc}
         * @throws IndexOutOfRangeException     {@inheritDoc}
         */
        public virtual void add(int index, E element) {
            throw new NotSupportedException();
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation always throws an
         * {@code UnsupportedOperationException}.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws IndexOutOfRangeException     {@inheritDoc}
         */
        public virtual E remove(int index) {
            throw new NotSupportedException();
        }


        // Search Operations

        /**
         * {@inheritDoc}
         *
         * <p>This implementation first gets a list iterator (with
         * {@code listIterator()}).  Then, it iterates over the list until the
         * specified element is found or the end of the list is reached.
         *
         * @throws ClassCastException   {@inheritDoc}
         * @throws NullPointerException {@inheritDoc}
         */
        public virtual int indexOf(Object o) {
	        ListIterator<E> e = listIterator();
	        if (o==null) {
	            while (e.hasNext())
		        if (e.next()==null)
		            return e.previousIndex();
	        } else {
	            while (e.hasNext())
		        if (o.Equals(e.next()))
		            return e.previousIndex();
	        }
	        return -1;
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation first gets a list iterator that points to the end
         * of the list (with {@code listIterator(size())}).  Then, it iterates
         * backwards over the list until the specified element is found, or the
         * beginning of the list is reached.
         *
         * @throws ClassCastException   {@inheritDoc}
         * @throws NullPointerException {@inheritDoc}
         */
        public virtual int lastIndexOf(Object o) {
	        ListIterator<E> e = listIterator(size());
	        if (o==null) {
	            while (e.hasPrevious())
		        if (e.previous()==null)
		            return e.nextIndex();
	        } else {
	            while (e.hasPrevious())
		        if (o.Equals(e.previous()))
		            return e.nextIndex();
	        }
	        return -1;
        }


        // Bulk Operations

        /**
         * Removes all of the elements from this list (optional operation).
         * The list will be empty after this call returns.
         *
         * <p>This implementation calls {@code removeRange(0, size())}.
         *
         * <p>Note that this implementation throws an
         * {@code UnsupportedOperationException} unless {@code remove(int
         * index)} or {@code removeRange(int fromIndex, int toIndex)} is
         * overridden.
         *
         * @throws UnsupportedOperationException if the {@code clear} operation
         *         is not supported by this list
         */
        public override void clear() {
            removeRange(0, size());
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation gets an iterator over the specified collection
         * and iterates over it, inserting the elements obtained from the
         * iterator into this list at the appropriate position, one at a time,
         * using {@code add(int, E)}.
         * Many implementations will override this method for efficiency.
         *
         * <p>Note that this implementation throws an
         * {@code UnsupportedOperationException} unless
         * {@link #add(int, Object) add(int, E)} is overridden.
         *
         * @throws UnsupportedOperationException {@inheritDoc}
         * @throws ClassCastException            {@inheritDoc}
         * @throws NullPointerException          {@inheritDoc}
         * @throws IllegalArgumentException      {@inheritDoc}
         * @throws IndexOutOfRangeException     {@inheritDoc}
         */
        public virtual bool addAll<T>(int index, Collection<T> c) where T : E {
	        bool modified = false;
	        Iterator<T> e = c.iterator();
	        while (e.hasNext()) {
	            add(index++, e.next());
	            modified = true;
	        }
	        return modified;
        }


        // Iterators

        /**
         * Returns an iterator over the elements in this list in proper sequence.
         *
         * <p>This implementation returns a straightforward implementation of the
         * iterator interface, relying on the backing list's {@code size()},
         * {@code get(int)}, and {@code remove(int)} methods.
         *
         * <p>Note that the iterator returned by this method will throw an
         * {@code UnsupportedOperationException} in response to its
         * {@code remove} method unless the list's {@code remove(int)} method is
         * overridden.
         *
         * <p>This implementation can be made to throw runtime exceptions in the
         * face of concurrent modification, as described in the specification
         * for the (protected) {@code modCount} field.
         *
         * @return an iterator over the elements in this list in proper sequence
         *
         * @see #modCount
         */
        public override Iterator<E> iterator() {
	        return new Itr<E>(this, modCount);
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation returns {@code listIterator(0)}.
         *
         * @see #listIterator(int)
         */
        public virtual ListIterator<E> listIterator() {
	        return listIterator(0);
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation returns a straightforward implementation of the
         * {@code ListIterator} interface that extends the implementation of the
         * {@code Iterator} interface returned by the {@code iterator()} method.
         * The {@code ListIterator} implementation relies on the backing list's
         * {@code get(int)}, {@code set(int, E)}, {@code add(int, E)}
         * and {@code remove(int)} methods.
         *
         * <p>Note that the list iterator returned by this implementation will
         * throw an {@code UnsupportedOperationException} in response to its
         * {@code remove}, {@code set} and {@code add} methods unless the
         * list's {@code remove(int)}, {@code set(int, E)}, and
         * {@code add(int, E)} methods are overridden.
         *
         * <p>This implementation can be made to throw runtime exceptions in the
         * face of concurrent modification, as described in the specification for
         * the (protected) {@code modCount} field.
         *
         * @throws IndexOutOfRangeException {@inheritDoc}
         *
         * @see #modCount
         */
        public virtual ListIterator<E> listIterator(int index) {
            if (index < 0 || index > size())
            {
                throw new IndexOutOfRangeException("Index: " + index.ToString());
            }
            return new ListItr<E>(this, index);
        }

        /**
         * {@inheritDoc}
         *
         * <p>This implementation returns a list that subclasses
         * {@code AbstractList}.  The subclass stores, in private fields, the
         * offset of the subList within the backing list, the size of the subList
         * (which can change over its lifetime), and the expected
         * {@code modCount} value of the backing list.  There are two variants
         * of the subclass, one of which implements {@code RandomAccess}.
         * If this list implements {@code RandomAccess} the returned list will
         * be an instance of the subclass that implements {@code RandomAccess}.
         *
         * <p>The subclass's {@code set(int, E)}, {@code get(int)},
         * {@code add(int, E)}, {@code remove(int)}, {@code addAll(int,
         * Collection)} and {@code removeRange(int, int)} methods all
         * delegate to the corresponding methods on the backing abstract list,
         * after bounds-checking the index and adjusting for the offset.  The
         * {@code addAll(Collection c)} method merely returns {@code addAll(size,
         * c)}.
         *
         * <p>The {@code listIterator(int)} method returns a "wrapper object"
         * over a list iterator on the backing list, which is created with the
         * corresponding method on the backing list.  The {@code iterator} method
         * merely returns {@code listIterator()}, and the {@code size} method
         * merely returns the subclass's {@code size} field.
         *
         * <p>All methods first check to see if the actual {@code modCount} of
         * the backing list is equal to its expected value, and throw a
         * {@code ConcurrentModificationException} if it is not.
         *
         * @throws IndexOutOfRangeException endpoint index value out of range
         *         {@code (fromIndex < 0 || toIndex > size)}
         * @throws IllegalArgumentException if the endpoint indices are out of order
         *         {@code (fromIndex > toIndex)}
         */
        public virtual List<E> subList(int fromIndex, int toIndex) {
            return (this is RandomAccess ?
                    new RandomAccessSubList<E>(this, fromIndex, toIndex) :
                    new SubList<E>(this, fromIndex, toIndex));
        }

        // Comparison and hashing

        /**
         * Compares the specified object with this list for equality.  Returns
         * {@code true} if and only if the specified object is also a list, both
         * lists have the same size, and all corresponding pairs of elements in
         * the two lists are <i>equal</i>.  (Two elements {@code e1} and
         * {@code e2} are <i>equal</i> if {@code (e1==null ? e2==null :
         * e1.equals(e2))}.)  In other words, two lists are defined to be
         * equal if they contain the same elements in the same order.<p>
         *
         * This implementation first checks if the specified object is this
         * list. If so, it returns {@code true}; if not, it checks if the
         * specified object is a list. If not, it returns {@code false}; if so,
         * it iterates over both lists, comparing corresponding pairs of elements.
         * If any comparison returns {@code false}, this method returns
         * {@code false}.  If either iterator runs out of elements before the
         * other it returns {@code false} (as the lists are of unequal length);
         * otherwise it returns {@code true} when the iterations complete.
         * 
         * @param o the object to be compared for equality with this list
         * @return {@code true} if the specified object is equal to this list
         */
        public override bool Equals(Object o) {
	        if (o == this)
	            return true;
	        if (!(o is JavaLike.Util.List<E>))
	            return false;

	        ListIterator<E> e1 = listIterator();
	        ListIterator<object> e2 = ((List<object>) o).listIterator();
	        while(e1.hasNext() && e2.hasNext()) {
	            E o1 = e1.next();
	            Object o2 = e2.next();
	            if (!(o1==null ? o2==null : o1.Equals(o2)))
		        return false;
	        }
	        return !(e1.hasNext() || e2.hasNext());
        }

        /**
         * Returns the hash code value for this list.
         *
         * <p>This implementation uses exactly the code that is used to define the
         * list hash function in the documentation for the {@link List#hashCode}
         * method.
         *
         * @return the hash code value for this list
         */
        public override int GetHashCode() {
	        int hashCode = 1;
	        Iterator<E> i = iterator();
	        while (i.hasNext()) {
	            E obj = i.next();
	            hashCode = 31*hashCode + (obj==null ? 0 : obj.GetHashCode());
	        }
	        return hashCode;
        }

        /**
         * Removes from this list all of the elements whose index is between
         * {@code fromIndex}, inclusive, and {@code toIndex}, exclusive.
         * Shifts any succeeding elements to the left (reduces their index).
         * This call shortens the ArrayList by {@code (toIndex - fromIndex)}
         * elements.  (If {@code toIndex==fromIndex}, this operation has no
         * effect.)
         *
         * <p>This method is called by the {@code clear} operation on this list
         * and its subLists.  Overriding this method to take advantage of
         * the internals of the list implementation can <i>substantially</i>
         * improve the performance of the {@code clear} operation on this list
         * and its subLists.
         *
         * <p>This implementation gets a list iterator positioned before
         * {@code fromIndex}, and repeatedly calls {@code ListIterator.next}
         * followed by {@code ListIterator.remove} until the entire range has
         * been removed.  <b>Note: if {@code ListIterator.remove} requires linear
         * time, this implementation requires quadratic time.</b>
         *
         * @param fromIndex index of first element to be removed
         * @param toIndex index after last element to be removed
         */
        protected virtual void removeRange(int fromIndex, int toIndex) {
            ListIterator<E> it = listIterator(fromIndex);
            for (int i=0, n=toIndex-fromIndex; i<n; i++) {
                it.next();
                it.remove();
            }
        }

        /**
         * The number of times this list has been <i>structurally modified</i>.
         * Structural modifications are those that change the size of the
         * list, or otherwise perturb it in such a fashion that iterations in
         * progress may yield incorrect results.
         *
         * <p>This field is used by the iterator and list iterator implementation
         * returned by the {@code iterator} and {@code listIterator} methods.
         * If the value of this field changes unexpectedly, the iterator (or list
         * iterator) will throw a {@code ConcurrentModificationException} in
         * response to the {@code next}, {@code remove}, {@code previous},
         * {@code set} or {@code add} operations.  This provides
         * <i>fail-fast</i> behavior, rather than non-deterministic behavior in
         * the face of concurrent modification during iteration.
         *
         * <p><b>Use of this field by subclasses is optional.</b> If a subclass
         * wishes to provide fail-fast iterators (and list iterators), then it
         * merely has to increment this field in its {@code add(int, E)} and
         * {@code remove(int)} methods (and any other methods that it overrides
         * that result in structural modifications to the list).  A single call to
         * {@code add(int, E)} or {@code remove(int)} must add no more than
         * one to this field, or the iterators (and list iterators) will throw
         * bogus {@code ConcurrentModificationExceptions}.  If an implementation
         * does not wish to provide fail-fast iterators, this field may be
         * ignored.
         */
        protected int modCount = 0;

        // 継承クラスで定義するためここでは実装しない
        //public override int size()
        //{
        //    throw new NotImplementedException();
        //}

        public override IEnumerator<E> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class SubList<E> : AbstractList<E> {
        private AbstractList<E> l;
        private int offset;
        private int listSize;
        private int expectedModCount;

        public SubList(AbstractList<E> list, int fromIndex, int toIndex) {
            if (fromIndex < 0)
                throw new IndexOutOfRangeException("fromIndex = " + fromIndex);
            if (toIndex > list.size())
                throw new IndexOutOfRangeException("toIndex = " + toIndex);
            if (fromIndex > toIndex)
                throw new ArgumentException("fromIndex(" + fromIndex +
                                                   ") > toIndex(" + toIndex + ")");
            l = list;
            offset = fromIndex;
            listSize = toIndex - fromIndex;
            expectedModCount = modCount;
        }

        public override E set(int index, E element) {
            rangeCheck(index);
            checkForComodification();
            return l.set(index+offset, element);
        }

        public override E get(int index) {
            rangeCheck(index);
            checkForComodification();
            return l.get(index+offset);
        }

        public override int size()
        {
            checkForComodification();
            return listSize;
        }

        public override void add(int index, E element) {
            if (index<0 || index > size())
                throw new IndexOutOfRangeException();
            checkForComodification();
            l.add(index+offset, element);
            expectedModCount = modCount;
            listSize++;
            modCount++;
        }

        public override E remove(int index) {
            rangeCheck(index);
            checkForComodification();
            E result = l.remove(index+offset);
            expectedModCount = modCount;
            listSize--;
            modCount++;
            return result;
        }

        protected override void removeRange(int fromIndex, int toIndex) {
            checkForComodification();
            removeRange(fromIndex+offset, toIndex+offset);
            expectedModCount = modCount;
            listSize -= (toIndex - fromIndex);
            modCount++;
        }

        public override bool addAll<T>(Collection<T> c)
        {
            return addAll(listSize, c);
        }

        public override bool addAll<T>(int index, Collection<T> c)
        {
            if (index<0 || index > size())
                throw new IndexOutOfRangeException("Index: "+index.ToString() +", Size: " + size().ToString());
            int cSize = c.size();
            if (cSize==0)
                return false;

            checkForComodification();
            l.addAll(offset+index, c);
            expectedModCount = modCount;
            listSize += cSize;
            modCount++;
            return true;
        }

        public override Iterator<E> iterator() {
            return listIterator();
        }

        private class ListIteratorImpl<LII> : ListIterator<LII>
        {
            private readonly ListIterator<LII> i;
            private int size;
            private int offset;
            private int modCount = 0;
            private int expectedModCount = 0;

            public ListIteratorImpl(AbstractList<LII> l, int index, int offset, int size)
            {
                i = l.listIterator(index+offset);
                this.size = size;
                this.offset = offset;
            }

            public bool hasNext() {
                return nextIndex() < size;
            }

            public LII next() {
                if (hasNext())
                    return i.next();
                else
                    throw new IndexOutOfRangeException();
            }

            public bool hasPrevious() {
                return previousIndex() >= 0;
            }

            public LII previous() {
                if (hasPrevious())
                    return i.previous();
                else
                    throw new IndexOutOfRangeException();
            }

            public int nextIndex() {
                    return i.nextIndex() - offset;
                }

                public int previousIndex() {
                    return i.previousIndex() - offset;
                }

                public void remove() {
                    i.remove();
                    expectedModCount = modCount;
                    size--;
                    modCount++;
                }

                public void set(LII e) {
                    i.set(e);
                }

                public void add(LII e) {
                    i.add(e);
                    expectedModCount = modCount;
                    size++;
                    modCount++;
                }
    
        }

        public override ListIterator<E> listIterator(int index) {
            checkForComodification();
            if (index<0 || index > size())
            {
                throw new IndexOutOfRangeException("Index: "+index+", Size: " + size());
            }
            return new ListIteratorImpl<E>(l, index, offset, size());
    
        }

        public override JavaLike.Util.List<E> subList(int fromIndex, int toIndex) {
            return new SubList<E>(this, fromIndex, toIndex);
        }

        private void rangeCheck(int index) {
            if (index<0 || index >= size())
                throw new IndexOutOfRangeException("Index: " + index +
                                                    ",Size: " + size());
        }

        private void checkForComodification() {
            if (modCount != expectedModCount)
                throw new ConcurrentModificationException();
        }

        public override IEnumerator<E> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class RandomAccessSubList<E> : SubList<E> , RandomAccess {
        public RandomAccessSubList(AbstractList<E> list, int fromIndex, int toIndex)
            : base(list, fromIndex, toIndex)
        {
        }

        public override List<E> subList(int fromIndex, int toIndex) {
            return new RandomAccessSubList<E>(this, fromIndex, toIndex);
        }
    }

    class ListItr<E> : Itr<E>, ListIterator<E>
    {
        public ListItr(AbstractList<E> l, int index) : base(l, index)
        {
            cursor = index;
        }

        public bool hasPrevious()
        {
            return cursor != 0;
        }

        public E previous()
        {
            checkForComodification();
            try
            {
                int i = cursor - 1;
                E previous = l.get(i);
                lastRet = cursor = i;
                return previous;
            }
            catch (IndexOutOfRangeException)
            {
                checkForComodification();
                throw new NoSuchElementException();
            }
        }

        public int nextIndex()
        {
            return cursor;
        }

        public int previousIndex()
        {
            return cursor - 1;
        }

        public void set(E e)
        {
            if (lastRet == -1)
                throw new IllegalStateException();
            checkForComodification();

            try
            {
                l.set(lastRet, e);
                expectedModCount = modCount;
            }
            catch (IndexOutOfRangeException)
            {
                throw new ConcurrentModificationException();
            }
        }

        public void add(E e)
        {
            checkForComodification();

            try
            {
                l.add(cursor++, e);
                lastRet = -1;
                expectedModCount = modCount;
            }
            catch (IndexOutOfRangeException)
            {
                throw new ConcurrentModificationException();
            }
        }
    }

    class Itr<E> : Iterator<E>
    {
        protected AbstractList<E> l;

        /**
         * Index of element to be returned by subsequent call to next.
         */
        protected int cursor = 0;

        /**
         * Index of element returned by most recent call to next or
         * previous.  Reset to -1 if this element is deleted by a call
         * to remove.
         */
        protected int lastRet = -1;

        protected int modCount;

        /**
         * The modCount value that the iterator believes that the backing
         * List should have.  If this expectation is violated, the iterator
         * has detected concurrent modification.
         */
        protected int expectedModCount = 0;

        public Itr(AbstractList<E> l, int modCount)
        {
            this.l = l;
            this.modCount = modCount;
        }

        public bool hasNext()
        {
            return cursor != l.size();
        }

        public E next()
        {
            checkForComodification();
            try
            {
                E next = l.get(cursor);
                lastRet = cursor++;
                return next;
            }
            catch (IndexOutOfRangeException)
            {
                checkForComodification();
                throw new NoSuchElementException();
            }
        }

        public void remove()
        {
            if (lastRet == -1)
            {
                throw new IllegalStateException();
            }
            checkForComodification();

            try
            {
                l.remove(lastRet);
                if (lastRet < cursor)
                    cursor--;
                lastRet = -1;
                expectedModCount = modCount;
            }
            catch (IndexOutOfRangeException)
            {
                throw new ConcurrentModificationException();
            }
        }

        public void checkForComodification()
        {
            if (modCount != expectedModCount)
                throw new ConcurrentModificationException();
        }
    }
}
