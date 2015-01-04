using System.IO;

namespace DBFlute.JavaLike.IO
{
    // #pending テストコード未実装
    /// <summary>
    /// [Java]OutputStream
    /// </summary>
    public abstract class OutputStream
    {
        protected readonly BufferedStream _writer;

        public OutputStream()
        {
            _writer = new BufferedStream(new MemoryStream());
        }

        public OutputStream(Stream st)
        {
            _writer = new BufferedStream(st);
        }

        public void close()
        {
            _writer.Flush();
            _writer.Close();
        }

        public void write(byte[] buf, int offset, int length)
        {
            _writer.Write(buf, offset, length);
        }
    }
}
