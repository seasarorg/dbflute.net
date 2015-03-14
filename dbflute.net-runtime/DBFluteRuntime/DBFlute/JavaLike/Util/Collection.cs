using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Util
{
    /// <summary>
    /// Javaコレクションインターフェース
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class Collection<ELEMENT> : System.Collections.IEnumerable, ICollection<ELEMENT>
    {
        private readonly ICollection<ELEMENT> _res;
        public Collection(ICollection<ELEMENT> res)
        {
            _res = res;
        }

        public static List<ELEMENT> emptyList()
        {
            return new ArrayList<ELEMENT>();
        }

        public int size()
        {
            return _res.Count;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(ELEMENT item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ELEMENT item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ELEMENT[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(ELEMENT item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<ELEMENT> IEnumerable<ELEMENT>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
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

    /// <summary>
    /// Collection拡張定義クラス
    /// </summary>
    public static class CollectionExtension
    {
        public static int size<ELEMENT>(this ICollection<ELEMENT> elements)
        {
            return elements.Count;
        }
    }
}
