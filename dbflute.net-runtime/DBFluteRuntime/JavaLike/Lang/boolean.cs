
namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// [java]boolean - [C#]bool 関連付け
    /// </summary>
    public sealed class boolean
    {
        public static readonly boolean BOOLEAN_TRUE = new boolean(true);
        public static readonly boolean BOOLEAN_FALSE = new boolean(false);

        private bool isTrue;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isTrue">初期化フラグ</param>
        private boolean(bool isTrue)
        {
            this.isTrue = isTrue;
        }
        
        /// <summary>
        /// true演算子
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator true(boolean b) 
        {
            return b.isTrue == true; 
        }

        /// <summary>
        /// false演算子
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator false(boolean b) 
        {
            return b.isTrue == false; 
        }

        /// <summary>
        /// &演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static boolean operator &(boolean a, boolean b)
        {
            return (a.isTrue & b.isTrue);
        }

        /// <summary>
        /// |演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static boolean operator |(boolean a, boolean b)
        {
            return (a.isTrue | b.isTrue);
        }

        /// <summary>
        /// キャスト演算子
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static implicit operator bool (boolean b)
        {
            return b.isTrue;
        }

        /// <summary>
        /// キャスト演算子
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static implicit operator boolean(bool b)
        {
            return b ? BOOLEAN_TRUE : BOOLEAN_FALSE;
        }

        /// <summary>
        /// 文字列化した場合は実際のフラグを返す
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return isTrue ? "true" : "false";
        }
    }
}