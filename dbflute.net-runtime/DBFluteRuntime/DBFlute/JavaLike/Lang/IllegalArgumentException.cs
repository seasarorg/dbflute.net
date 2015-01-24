using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.Lang
{
    public class IllegalArgumentException : ArgumentException
    {
        public IllegalArgumentException(string message) : base(message) { }
    }
}
