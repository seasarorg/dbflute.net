
namespace DBFlute.JavaLike.Lang
{
    /// <summary>
    /// [Java]String用拡張クラス
    /// </summary>
    public static class StringExtension
    {
        public static string trim(this string value)
        {
            return value.Trim();
        }

        public static int length(this string value)
        {
            return value.Length;
        }

        public static int length(this string[] values)
        {
            return values.Length;
        }

        public static string valueOf(int value)
        {
            return value.ToString();
        }

        public static string valueOf(long value)
        {
            return value.ToString();
        }

        public static string valueOf(char value)
        {
            return value.ToString();
        }

        public static string valueOf(bool value)
        {
            return value ? "true" : "false";
        }

        public static string toUpperCase(this string target)
        {
            return target.ToUpper();
        }

        public static string toLowerCase(this string target)
        {
            return target.toLowerCase();
        }

        public static char[] toCharArray(this string target)
        {
            return target.ToCharArray();
        }

        public static char charAt(this string target, int index)
        {
            return target[index];
        }

        public static int indexOf(this string target, string keyword)
        {
            return target.IndexOf(keyword);
        }

        public static int indexOf(this string target, string keyword, int startIndex)
        {
            return target.IndexOf(keyword, startIndex);
        }

        public static int lastIndexOf(this string target, string keyword)
        {
            return target.LastIndexOf(keyword);
        }

        public static bool endsWith(this string target, string keyword)
        {
            return target.EndsWith(keyword);
        }

        public static bool startsWith(this string target, string keyword)
        {
            return target.StartsWith(keyword);
        }

        public static string substring(this string target, int startIndex)
        {
            return target.Substring(startIndex);
        }

        public static string substring(this string target, int startIndex, int length)
        {
            return target.Substring(startIndex, length);
        }

        public static bool contains(this string target, string keyword)
        {
            return target.Contains(keyword);
        }

        public static bool equalsIgnoreCase(this string target, string value)
        {
            return target.Equals(value, System.StringComparison.CurrentCultureIgnoreCase);
        }

        public static string replaceAll(this string target, string oldValue, string newValue)
        {
            return target.Replace(oldValue, newValue);
        }
    }
}
