using DBFlute.JavaLike.Helper;
using System.Linq;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// 配列変換処理クラス
    /// </summary>
    public static class Arrays
    {
        /// <summary>
        /// 配列からリストへの変換
        /// </summary>
        /// <typeparam name="ELEMENT"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static List<ELEMENT> asList<ELEMENT>(ELEMENT[] args)
        {
            ArrayList<ELEMENT> ret = new ArrayList<ELEMENT>();
            foreach(ELEMENT arg in args)
            {
                ret.add(arg);
            }
            return ret;
        }

        /// <summary>
        /// 配列からC#リストへの変換
        /// </summary>
        /// <typeparam name="ELEMENT"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static System.Collections.Generic.List<ELEMENT> asListCS<ELEMENT>(ELEMENT[] args)
        {
            System.Collections.Generic.List<ELEMENT> ret = new System.Collections.Generic.List<ELEMENT>(args.Length);
            foreach(ELEMENT arg in args)
            {
                ret.Add(arg);
            }
            return ret;
        }

        /// <summary>
        /// 配列同士の比較
        /// </summary>
        /// <typeparam name="ELEMENT"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static bool equals<ELEMENT>(ELEMENT[] arg1, ELEMENT[] arg2)
        {
            if (arg1 == arg2)
            {
                return true;
            }
            if (arg1 == null || arg2 == null)
            {
                return false;
            }

            if (arg1.Length != arg2.Length)
            {
                return false;
            }

            for (int i = 0; i < arg1.Length; i++)
            {
                if (!arg1[i].Equals(arg2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 配列ソート
        /// </summary>
        /// <typeparam name="ELEMENT"></typeparam>
        /// <param name="a"></param>
        /// <param name="c"></param>
        public static void sort<ELEMENT>(ELEMENT[] a, Comparater<ELEMENT> c)
        {
            System.Collections.Generic.List<ELEMENT> sortList = asListCS(a);

            sortList.Sort((x, y) => c(x, y));
            for(int i = 0; i < sortList.Count(); i++)
            {
                // ソート後の順番で配列を再設定
                a[i] = sortList[i];
            }
        }
    }
}
