
namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// Javaイテレータインターフェース
    /// </summary>
    /// <typeparam name="ELEMENT">イテレータ内要素の型</typeparam>
    public interface Iterator<ELEMENT>
    {
        bool hasNext();
        ELEMENT next();
    }
}
