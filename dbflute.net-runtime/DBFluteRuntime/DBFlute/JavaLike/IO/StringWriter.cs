using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.IO
{
    // #pending 未実装
    /// <summary>
    /// [Java]StringWriter
    /// </summary>
    public class StringWriter : Writer
    {
        public override string ToString()
        {
            throw new NotSupportedException();
        }

        public override void write(char[] cbuf, int offset, int length)
        {
            throw new NotImplementedException();
        }
    }
}
