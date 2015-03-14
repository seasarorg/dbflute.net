
using System.Collections.Generic;
namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// [Java]Setインターフェース
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public interface Set<ELEMENT> : IEnumerable<ELEMENT>, ICollection<ELEMENT>
    {
        bool contains(ELEMENT element);
        void add(ELEMENT element);
        bool addAll(ICollection<ELEMENT> element);
        int size();
    }

    /// <summary>
    /// [Java]Setインターフェース（非ジェネリック）
    /// </summary>
    public interface NgSet : NgCollection
    {
        bool containsAsNg(object element);
    }
}
