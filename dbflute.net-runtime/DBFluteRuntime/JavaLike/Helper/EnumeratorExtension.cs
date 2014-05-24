using System.Collections;

namespace DBFluteRuntime.JavaLike.Helper
{
    /// <summary>
    /// [C#]IEnumerator拡張
    /// </summary>
    public static class EnumeratorExtension
    {
        /// <summary>
        /// 次要素の参照（ない場合はnull）
        /// </summary>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        public static object next(this IEnumerator enumerator)
        {
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
            return null;
        }
    }
}
