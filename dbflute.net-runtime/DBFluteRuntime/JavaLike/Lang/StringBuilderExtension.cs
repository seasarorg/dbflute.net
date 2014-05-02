using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.Lang
{
    public static class StringBuilderExtension
    {
        public static StringBuilder append(this StringBuilder builder, Object obj)
        {
            builder.Append(obj != null ? obj.ToString() : "null");
            return builder;
        }
        public static StringBuilder insert(this StringBuilder builder, int offset, Object obj)
        {
            builder.Insert(offset, obj);
            return builder;
        }
        public static StringBuilder delete(this StringBuilder builder, int start, int end)
        {
            builder.Remove(start, end - start);
            return builder;
        }
        public static int length(this StringBuilder builder)
        {
            return builder.Length;
        }
    }
}
