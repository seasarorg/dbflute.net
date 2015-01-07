
namespace DBFlute.JavaLike.Lang
{
    /// <summary>
    /// クラス名からインスタンスを生成できなかった場合の例外
    /// </summary>
    public class ClassNotFoundException : System.Exception
    {
        public ClassNotFoundException() : base() { }
        public ClassNotFoundException(string message) : base(message) { }
        public ClassNotFoundException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
