using DBFluteRuntime.JavaLike.Lang;
using System;
using System.Reflection;

namespace DBFluteRuntime.JavaLike.Helper
{
    /// <summary>
    /// クラス情報操作ユーティリティ
    /// </summary>
    public static class ClassUtils
    {
        /// <summary>
        /// インスタンス生成
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static object createInstance(string className)
        {
            Type type = getTypeFromName(className);
            if (type == null)
            {
                throw new ClassNotFoundException(className);
            }
            return Activator.CreateInstance(type);
        }

        /// <summary>
        /// 型情報の取得
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static Type getTypeFromName(string className)
        {
            return getTypeFromName(className, AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// 型情報の取得
        /// </summary>
        /// <param name="className"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        private static Type getTypeFromName(string className, Assembly[] assemblies)
        {
            Type type = Type.GetType(className);
            if (type != null)
            {
                return type;
            }
            
            foreach (Assembly assembly in assemblies)
            {
                type = assembly.GetType(className);
                if (type != null)
                {
                    return type;
                }
            }
            return null;
        }
    }
}
