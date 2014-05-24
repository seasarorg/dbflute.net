using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.IO
{
    // #pending 未実装
    /// <summary>
    /// [Java]ObjectOutputStream
    /// </summary>
    public class ObjectOutputStream : OutputStream
    {
        public void writeObject(object obj)
        {
            throw new NotSupportedException();
        }
    }
}
