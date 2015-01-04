using DBFlute.JavaLike.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.Util
{
    // #pending 未実装
    /// <summary>
    /// [Java]Properties
    /// </summary>
    public class Properties : Dictionary<object, string>
    {
        public string getProperty(string key)
        {
            throw new NotSupportedException();
        }

        public void load(InputStream stream)
        {
            throw new NotSupportedException();
        }
    }
}
