﻿using System;

namespace DBFluteRuntime.JavaLike.Lang
{
    /**
     * This exception may be thrown by methods that have detected concurrent
     * modification of an object when such modification is not permissible.
     * <p>
     * For example, it is not generally permissible for one thread to modify a Collection
     * while another thread is iterating over it.  In general, the results of the
     * iteration are undefined under these circumstances.  Some Iterator
     * implementations (including those of all the general purpose collection implementations
     * provided by the JRE) may choose to throw this exception if this behavior is
     * detected.  Iterators that do this are known as <i>fail-fast</i> iterators,
     * as they fail quickly and cleanly, rather that risking arbitrary,
     * non-deterministic behavior at an undetermined time in the future.
     * <p>
     * Note that this exception does not always indicate that an object has
     * been concurrently modified by a <i>different</i> thread.  If a single
     * thread issues a sequence of method invocations that violates the
     * contract of an object, the object may throw this exception.  For
     * example, if a thread modifies a collection directly while it is
     * iterating over the collection with a fail-fast iterator, the iterator
     * will throw this exception.
     *
     * <p>Note that fail-fast behavior cannot be guaranteed as it is, generally
     * speaking, impossible to make any hard guarantees in the presence of
     * unsynchronized concurrent modification.  Fail-fast operations
     * throw <tt>ConcurrentModificationException</tt> on a best-effort basis. 
     * Therefore, it would be wrong to write a program that depended on this
     * exception for its correctness: <i><tt>ConcurrentModificationException</tt>
     * should be used only to detect bugs.</i>
     *
     * @author  Josh Bloch
     * @version %I%, %G%
     * @see	    Collection
     * @see     Iterator
     * @see     ListIterator
     * @see	    Vector
     * @see	    LinkedList
     * @see	    HashSet
     * @see	    Hashtable
     * @see	    TreeMap
     * @see	    AbstractList
     * @since   1.2
     */
    public class ConcurrentModificationException : Exception
    {
        public ConcurrentModificationException() : base()
        { }

        public ConcurrentModificationException(string message) : base(message)
        { }

        public ConcurrentModificationException(string message, Exception cause)
            : base(message, cause)
        { }
    }
}
