using System;
using System.Linq;
using System.Reflection;

namespace DBFlute.JavaLike.Lang.Reflect
{
    // #pending テストクラス未作成
    /// <summary>
    ///  [Java]Methodクラス([C#]MethodInfo拡張）
    /// </summary>
    public static class MethodExtension
    {
        public static object invoke(this MethodInfo method, object target, object[] args)
        {
            return method.Invoke(target, args);
        }

        public static Type getReturnType(this MethodInfo method)
        {
            return method.ReturnType;
        }

        public static string getName(this MethodInfo method)
        {
            return method.Name;
        }

        public static Type getDeclaringClass(this MethodInfo method)
        {
            return method.DeclaringType;
        }

        public static Type[] getParameterTypes(this MethodInfo method)
        {
            return method.GetParameters().Select(pi => pi.ParameterType).ToArray();
        }

        public static void setAccessible(this MethodInfo method, boolean flag)
        {
            // #pending C#に対応するメソッドがあるか？要調査[setAccessible]メソッド
            throw new NotSupportedException();
        }       
    }
}
