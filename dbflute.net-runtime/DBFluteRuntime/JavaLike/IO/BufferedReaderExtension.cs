using System.IO;

namespace DBFlute.JavaLike.IO
{
    /// <summary>
    /// [Java]BufferedReaderクラスの拡張
    /// </summary>
    /// <remarks>
    /// ファイルI/O C#とJavaの比較
    /// http://msdn.microsoft.com/ja-jp/library/ms228592(v=vs.90).aspx
    /// </remarks>
    public static class BufferedReaderExtension
    {
        public static string readLine(this StreamReader reader)
        {
            return reader.ReadLine();
        }

        public static int read(this StreamReader reader, char[] cbuf)
        {
            return reader.Read(cbuf, 0, cbuf.Length);
        }

        public static void close(this StreamReader reader)
        {
            reader.Close();
        }
    }
}
