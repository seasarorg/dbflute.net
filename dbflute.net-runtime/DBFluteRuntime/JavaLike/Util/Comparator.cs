
namespace DBFluteRuntime.JavaLike.Util
{
    /// <summary>
    /// [Java]比較インターフェース
    /// </summary>
    /// <typeparam name="ELEMENT"></typeparam>
    public interface Comparator<ELEMENT>
    {
        int compare(ELEMENT o1, ELEMENT o2);
        bool equals(object obj);
    }
}
