using DBFlute.JavaLike.Lang;

namespace DBFlute.JavaLike.IO
{
    /// <summary>
    /// [Java]FileFilter
    /// A filter for abstract pathnames.
    /// Instances of this interface may be passed to the listFiles(FileFilter) method of the File class.
    /// </summary>
    public interface FileFilter
    {
        /// <summary>
        /// Tests whether or not the specified abstract pathname should be included in a pathname list.
        /// </summary>
        /// <param name="pathname">The abstract pathname to be tested</param>
        /// <returns>true if and only if pathname should be included</returns>
        boolean accept(File pathname);
    }
}
