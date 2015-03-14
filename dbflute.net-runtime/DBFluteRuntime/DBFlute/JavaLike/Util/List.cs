using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// Javaリストインターフェース
    /// </summary>
    /// <typeparam name="ELEMENT">リスト内要素の型</typeparam>
    public interface List<ELEMENT> : ICollection<ELEMENT>
    {
        ELEMENT get(int index);
        ELEMENT set(int index, ELEMENT element);
        bool add(ELEMENT element);
        bool addAll(ICollection<ELEMENT> elements);
        ELEMENT remove(int index);
        void removeAll();
        void removeAll(ICollection<ELEMENT> elements);
        bool remove(ELEMENT element);
        List<ELEMENT> subList(int fromIndex, int toIndex);
        IList<ELEMENT> getList();
        ICollection<ELEMENT> getCollection();
        int indexOf(ELEMENT element);
        int size();
        bool isEmpty();
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
