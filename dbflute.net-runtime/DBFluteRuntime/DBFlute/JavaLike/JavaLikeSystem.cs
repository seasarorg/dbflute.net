using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike
{
    public static class JavaLikeSystem
    {
        public static long currentTimeMillis()
        {
            return (long)DateTime.Now.Millisecond;
        }
    }
}
