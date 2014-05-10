using System;
using System.Reflection;

namespace DBFluteRuntime.JavaLike.Lang.Reflect
{
    // #pending テストクラス未作成
    /// <summary>
    /// [Java]Fieldクラス（[C#]FieldInfo拡張）
    /// </summary>
    public static class FieldExtension
    {
        public static void setAccessible(this FieldInfo field, boolean flag)
        {
            // #pending C#に対応するメソッドがあるか？要調査[setAccessible]メソッド
            throw new NotSupportedException();
        }

        /// <summary>
        /// [Java]setメソッドの代用
        /// </summary>
        /// <param name="field"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void setValue(this FieldInfo field, object target, object value)
        {
            field.SetValue(target, value);
        }

        /// <summary>
        /// [Java]getメソッドの代用
        /// </summary>
        /// <param name="field"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static object getValue(this FieldInfo field, object target)
        {
            return field.GetValue(target);
        }

        // #pending getModifiersメソッド 対応するメソッドがC#にないかも？
    }
}
