using DBFlute.JavaLike.Util;

namespace DBFlute.JavaLike.Lang
{
    /// <summary>
    /// as java.lang.Iterable interface
    /// </summary>
    /// <remarks>
    /// /** Implementing this interface allows an object to be the target of
    ///  *  the "foreach" statement.
    ///  * @since 1.5
    ///  */
    /// </remarks>
    public interface Iterable<T>
    {
        /**
         * Returns an iterator over a set of elements of type T.
         * 
         * @return an Iterator.
         */
        Iterator<T> iterator();
    }
}
