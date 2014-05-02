
namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// [Java]String用拡張クラス
    /// </summary>
    public static class StringExtension
    {
        public static string trim(this string s)
        {
            return s.Trim();
        }

        public static int length(this string s)
        {
            return s.Length;
        }

        public static string valueOf(int v)
        {
            return v.ToString();
        }

        public static string valueOf(char c)
        {
            return c.ToString();
        }

        public static string valueOf(bool b)
        {
            return b ? "true" : "false";
        }
    }
}
