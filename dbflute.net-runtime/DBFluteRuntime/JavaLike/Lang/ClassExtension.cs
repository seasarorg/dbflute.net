using System;
using Constructor = System.Reflection.ConstructorInfo;

namespace DBFlute.JavaLike.Lang
{
    // #pending テストクラス未作成
    /// <summary>
    /// [Java]Classクラス([C#]Type拡張)
    /// </summary>
    public static class ClassExtension
    {
        public static string getName(this Type t)
        {
            return t.Name;
        }

        public static Constructor[] getConstructors(this Type t)
        {
            return t.GetConstructors();
        }

        public static Constructor getConstructor(this Type t, Type[] argTypes)
        {
           
            return t.GetConstructor(argTypes);
        }
    }
}
