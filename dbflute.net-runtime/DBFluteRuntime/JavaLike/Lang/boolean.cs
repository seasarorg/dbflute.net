
namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// javaのboolean型用定義
    /// </summary>
    public sealed class boolean
    {
        private bool isTrue;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isTrue">初期化フラグ</param>
        public boolean(bool isTrue)
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
            return new boolean(b);
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