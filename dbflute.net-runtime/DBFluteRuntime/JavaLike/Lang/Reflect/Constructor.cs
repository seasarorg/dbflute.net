using System;
using System.Linq;
using System.Reflection;

namespace DBFluteRuntime.JavaLike.Lang.Reflect
{
    // #pending テストクラス未作成
    /// <summary>
    /// [Java]Constructorクラス
    /// </summary>
    public sealed class Constructor
    {
        private readonly ConstructorInfo _constructor;

        public Constructor(ConstructorInfo constructor)
        {
            _constructor = constructor;
        }

        public Type[] getParameterTypes()
        {
            return _constructor.GetParameters().Select(pi => pi.ParameterType).ToArray();
        }

        public object newInstance(object[] args)
        {
            return _constructor.Invoke(args);
        }
    }
}
