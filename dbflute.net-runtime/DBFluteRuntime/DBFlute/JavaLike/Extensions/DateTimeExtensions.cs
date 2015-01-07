using DBFlute.JavaLike.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.Extensions
{
    public static class DateTimeExtensions
    {
        public static Instant toInstant(this DateTime dt)
        {
            return new Instant();
        }
    }
}
