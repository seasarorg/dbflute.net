using System;
using System.Linq;
using System.Reflection;

namespace DBFluteRuntime.JavaLike.Lang.Reflect
{
    // #pending テストクラス未作成
    /// <summary>
    /// [Java]Methodクラス
    /// </summary>
    public sealed class Method
    {
        private readonly MethodInfo _method;

        public Method(MethodInfo method)
        {
            _method = method;
        }

        public object invoke(object target, object[] args)
        {
            return _method.Invoke(target, args);
        }

        public Type getReturnType()
        {
            return _method.ReturnType;
        }

        public string getName()
        {
            return _method.Name;
        }

        public Type getDeclaringClass()
        {
            return _method.DeclaringType;
        }

        public Type[] getParameterTypes()
        {
            return _method.GetParameters().Select(pi => pi.ParameterType).ToArray();
        }

        public void setAccessible(boolean flag)
        {
            // #pending C#に対応するメソッドがあるか？要調査[setAccessible]メソッド
        }       
    }
}
