using System;

namespace DBFluteRuntime.JavaLike.Lang
{
    // #pending getClassメソッドの対応
    /// <summary>
    /// java.lang.Objectの拡張クラス
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// java風toStringメソッド定義
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string toString(this Object o)
        {
            return o.ToString();
        }

        /// <summary>
        /// java風hashCodeメソッド定義
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int hashCode(this Object o)
        {
            return o.GetHashCode();
        }

        /// <summary>
        /// java風equalsメソッド定義
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool equals(this Object original, Object target)
        {
            return original.Equals(target);
        }
    }
}