
using System.Collections.Generic;
namespace DBFlute.JavaLike.Util
{
    ///// <summary>
    ///// [Java]比較インターフェース
    ///// </summary>
    ///// <typeparam name="ELEMENT"></typeparam>
    //public interface Comparator<ELEMENT>
    //{
    //    int compare(ELEMENT o1, ELEMENT o2);
    //    bool equals(object obj);
    //}

    /// <summary>
    /// 比較デリゲート
    /// </summary>
    /// <typeparam name="ELEMENT"></typeparam>
    /// <param name="o1"></param>
    /// <param name="o2"></param>
    /// <returns></returns>
    public delegate int Comparater<ELEMENT>(ELEMENT o1, ELEMENT o2);

    public class ComparaterAdapter<ELEMENT_TYPE> : IComparer<ELEMENT_TYPE>
    {
        private readonly Comparater<ELEMENT_TYPE> _comparater;

        public ComparaterAdapter(Comparater<ELEMENT_TYPE> comp)
        {
            _comparater = comp;
        }

        public int Compare(ELEMENT_TYPE x, ELEMENT_TYPE y)
        {
            throw new System.NotImplementedException();
        }
    }

}
