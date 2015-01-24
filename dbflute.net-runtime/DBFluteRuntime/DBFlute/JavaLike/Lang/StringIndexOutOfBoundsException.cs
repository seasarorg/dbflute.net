using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.Lang
{
    public class StringIndexOutOfBoundsException : ArgumentOutOfRangeException
    {
        public StringIndexOutOfBoundsException(string message) : base("", message) { }
    }
}
