using System;

namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// [Java]Classクラス用拡張
    /// </summary>
    public static class TypeExtension
    {
        public static string getName(this Type t)
        {
            return t.Name;
        }
    }
}
