using System.Reflection;

namespace DBFluteRuntime.JavaLike.Lang.Reflect
{
    // #pending テストクラス未作成
    /// <summary>
    /// [Java]Fieldクラス
    /// </summary>
    public sealed class Field
    {
        private readonly FieldInfo _field;

        public Field(FieldInfo fieldInfo)
        {
            _field = fieldInfo;
        }

        public void setAccessible(boolean flag)
        {
            // #pending C#に対応するメソッドがあるか？要調査[setAccessible]メソッド
        }

        /// <summary>
        /// [Java]setメソッドの代用
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void setValue(object target, object value)
        {
            _field.SetValue(target, value);
        }

        /// <summary>
        /// [Java]getメソッドの代用
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object getValue(object target)
        {
            return _field.GetValue(target);
        }

        // #pending getModifiersメソッド 対応するメソッドがC#にないかも？
    }
}
