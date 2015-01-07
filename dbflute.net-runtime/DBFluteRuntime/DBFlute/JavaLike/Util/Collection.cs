using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// Javaコレクションインターフェース
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public interface Collection<ELEMENT> : System.Collections.IEnumerable
    {
        bool add(ELEMENT element);
        bool addAll(Collection<ELEMENT> element);
        bool remove(ELEMENT element);
        int size();
        bool isEmpty();
        void clear();
        Iterator<ELEMENT> iterator();
        ICollection<ELEMENT> getCollection();
    }

    /// <summary>
    /// 非ジェネリックコレクションインターフェース
    /// </summary>
    public interface NgCollection
    {
        bool addAsNg(Object element);
        bool removeAsNg(Object element);
        System.Collections.ICollection getCollectionAsNg();
    }
}
