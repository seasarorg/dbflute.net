using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.IO
{
    // #pending 未実装
    /// <summary>
    /// [Java]ObjectInputStream
    /// </summary>
    public class ObjectInputStream : InputStream
    {
        public object readObject()
        {
            throw new NotSupportedException();
        }
    }
}
