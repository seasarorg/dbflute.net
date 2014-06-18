using System.IO;

namespace DBFluteRuntime.JavaLike.IO
{
    // #pending テストコード未実装
    /// <summary>
    /// [Java]FileOutputStream
    /// </summary>
    public class FileOutputStream : OutputStream
    {
        public FileOutputStream(string filePath) : base(new FileStream(filePath, FileMode.Append))
        {
        }
    }
}
