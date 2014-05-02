using System;
using System.Collections.Generic;

namespace DBFluteRuntime.JavaLike.Util
{
    /// <summary>
    /// Javaリストインターフェース
    /// </summary>
    /// <typeparam name="ELEMENT">リスト内要素の型</typeparam>
    public interface List<ELEMENT> : Collection<ELEMENT>
    {
        ELEMENT get(int index);
        ELEMENT set(int index, ELEMENT element);
        ELEMENT remove(int index);
        List<ELEMENT> subList(int fromIndex, int toIndex);
        IList<ELEMENT> getList();
    }

    /// <summary>
    /// Javaリストインターフェース（非ジェネリック）
    /// </summary>
    public interface NgList : NgCollection
    {
        Object getAsNg(int index);
        System.Collections.IList getListAsNg();
    }
}
