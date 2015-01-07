
namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]Setインターフェース
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public interface Set<ELEMENT> : Collection<ELEMENT>
    {
        bool contains(ELEMENT element);
    }

    /// <summary>
    /// [Java]Setインターフェース（非ジェネリック）
    /// </summary>
    public interface NgSet : NgCollection
    {
        bool containsAsNg(object element);
    }
}
