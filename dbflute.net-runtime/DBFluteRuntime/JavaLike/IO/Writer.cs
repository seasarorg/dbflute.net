using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.IO
{
    // #penging 未実装
    /// <summary>
    /// [Java]Writer
    /// </summary>
    public abstract class Writer
    {
        public void write(int c)
        {
            // synchronized
            throw new NotSupportedException();
        }

        public void write(char[] cbuf)
        {
            write(cbuf, 0, cbuf.Length);
        }

        public abstract void write(char[] cbuf, int offset, int length);

        public void write(string str)
        {
            write(str, 0, str.Length);
        }

        public void write(string str, int offset, int length)
        {
            // synchronized
            throw new NotSupportedException();
        }

        public void flush()
        {
            throw new NotSupportedException();
        }

        public void close()
        {
            throw new NotSupportedException();
        }
    }
}
