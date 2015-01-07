using System;
using System.Linq;
using System.Reflection;

namespace DBFlute.JavaLike.Lang.Reflect
{
    // #pending テストクラス未作成
    /// <summary>
    /// [Java]Constructorクラス（[C#]ContructorInfo拡張）
    /// </summary>
    public static class ConstructorExtension
    {
        public static Type[] getParameterTypes(this ConstructorInfo c)
        {
            return c.GetParameters().Select(pi => pi.ParameterType).ToArray();
        }

        public static object newInstance(this ConstructorInfo c, object[] args)
        {
            return c.Invoke(args);
        }
    }
}
