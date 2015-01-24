
namespace DBFlute.JavaLike.Lang
{
    /// <summary>
    /// 配列拡張クラス
    /// </summary>
    public static class ArrayExtension
    {
        public static int length<T>(this T[] array)
        {
            return array.Length;
        }
    }
}
