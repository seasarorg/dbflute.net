using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.IO
{
    // #pending 未実装
    /// <summary>
    /// [Java]OutputStream
    /// </summary>
    public abstract class OutputStream
    {
        public void close()
        {
            throw new NotSupportedException();
        }

        public void write(byte[] buf, int offset, int length)
        {
            throw new NotSupportedException();
        }
    }
}
