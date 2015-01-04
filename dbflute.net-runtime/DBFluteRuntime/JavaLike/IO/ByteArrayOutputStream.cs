
namespace DBFlute.JavaLike.IO
{
    // #pending テストコード未実装
    /// <summary>
    /// [Java]ByteArrayOutputStream
    /// </summary>
    public class ByteArrayOutputStream : OutputStream
    {
        private byte[] _buf = null;

        public ByteArrayOutputStream() : base()
        { }

        public byte[] toByteArray()
        {
            return _buf;
        }

        internal void setBytes(byte[] buf)
        {
            _buf = buf;
        }
    }
}
