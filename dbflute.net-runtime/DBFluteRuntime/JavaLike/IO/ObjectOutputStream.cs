using System.Text;

namespace DBFlute.JavaLike.IO
{
    /// <summary>
    /// [Java]ObjectOutputStream
    /// </summary>
    public class ObjectOutputStream : OutputStream
    {
        private readonly ByteArrayOutputStream _baos;
        public ObjectOutputStream(ByteArrayOutputStream baos) : base()
        {
            _baos = baos;
        }

        public void writeObject(object obj)
        {
            if (obj == null)
            {
                return;
            }

            byte[] target = null;
            if(obj is byte)
            {
                target = new byte[] { (byte)obj };
            }
            else if(obj is byte[])
            {
                target = (byte[])obj;
            }
            else if(obj is string)
            {
                target = Encoding.Unicode.GetBytes((string)obj);
            }
            // #pending バイト、文字列以外の型はテストコードを書きつつ検討
        }
    }
}
