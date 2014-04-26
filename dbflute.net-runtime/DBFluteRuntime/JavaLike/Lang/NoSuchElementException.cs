using System;

namespace DBFluteRuntime.JavaLike.Lang
{
    /**
     * Thrown by the <code>nextElement</code> method of an 
     * <code>Enumeration</code> to indicate that there are no more 
     * elements in the enumeration. 
     *
     * @author  unascribed
     * @version %I%, %G%
     * @see     java.util.Enumeration
     * @see     java.util.Enumeration#nextElement()
     * @since   JDK1.0
     */
    public class NoSuchElementException : Exception
    {
        public NoSuchElementException() : base()
        { }

        public NoSuchElementException(string message) : base(message)
        { }

        public NoSuchElementException(string message, Exception cause)
            : base(message, cause)
        { }
    }
}
