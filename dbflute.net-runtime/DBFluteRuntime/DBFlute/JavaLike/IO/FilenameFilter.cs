using DBFlute.JavaLike.Lang;

namespace DBFlute.JavaLike.IO
{
    /// <summary>
    /// [Java]FilenameFilter
    /// Instances of classes that implement this interface are used to filter filenames. These instances are used to filter directory listings in the list method of class File, and by the Abstract Window Toolkit's file dialog component.
    /// </summary>
    public interface FilenameFilter
    {
        /// <summary>
        /// Tests if a specified file should be included in a file list.
        /// </summary>
        /// <param name="dir"> the directory in which the file was found.</param>
        /// <param name="name"> the name of the file.</param>
        /// <returns>true if and only if the name should be included in the file list; false otherwise.</returns>
        boolean accept(File dir, string name);
        
    }
}
