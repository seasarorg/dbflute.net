using DBFlute.JavaLike.Util;

namespace DBFlute.JavaLike.Helper
{
    /// <summary>
    /// 文字列処理ヘルパークラス
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// コレクションから文字列への変換
        /// </summary>
        /// <typeparam name="ELEMENT"></typeparam>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static string collectionToString<ELEMENT>(Collection<ELEMENT> elements)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{");
            int index = 0;
            foreach (ELEMENT element in elements)
            {
                if (index > 0) { sb.Append(", "); }
                sb.Append(element);
                ++index;
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
