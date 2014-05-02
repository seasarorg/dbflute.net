
namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// Null可能なクラスの拡張
    /// </summary>
    public static class NullableExtension
    {
        public static int intValue(this int? source)
        {
            return source.Value;
        }

        public static long longValue(this long? source)
        {
            return source.Value;
        }
    }
}
