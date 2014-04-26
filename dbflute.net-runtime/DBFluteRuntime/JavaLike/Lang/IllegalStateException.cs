using System;

namespace DBFluteRuntime.JavaLike.Lang
{
    /**
     * Signals that a method has been invoked at an illegal or
     * inappropriate time.  In other words, the Java environment or
     * Java application is not in an appropriate state for the requested
     * operation.
     *
     * @author  Jonni Kanerva
     * @version %I%, %G%
     * @since   JDK1.1
     */
    public class IllegalStateException : Exception
    {
        public IllegalStateException() : base()
        { }

        public IllegalStateException(string message) : base(message)
        { }

        public IllegalStateException(string message, Exception cause) : base(message, cause)
        { }
    }
}
