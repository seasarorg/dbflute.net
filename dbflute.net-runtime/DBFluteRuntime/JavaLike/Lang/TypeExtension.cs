using DBFluteRuntime.JavaLike.Lang.Reflect;
using System;
using System.Collections.Generic;

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

        public static Constructor[] getConstructors(this Type t)
        {
            List<Constructor> constructors = new List<Constructor>();
            foreach (var info in t.GetConstructors())
            {
                constructors.Add(new Constructor(info));
            }
            return constructors.ToArray();
        }

        public static Constructor getConstructor(this Type t, Type[] argTypes)
        {
            return new Constructor(t.GetConstructor(argTypes));
        }
    }
}
