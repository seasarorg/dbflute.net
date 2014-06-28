using System;

namespace DBFluteRuntime.JavaLike.IO
{
    /// <summary>
    /// [Java]ObjectInputStream
    /// </summary>
    public class ObjectInputStream : InputStream
    {
        public object readObject()
        {
            // #pending readObject中身未実装
            throw new NotSupportedException();
        }
    }
}
