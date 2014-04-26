using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.Util
{
    // TODO 未実装
    [Serializable]
    public class HashSet<E> : AbstractSet<E>, ICloneable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
