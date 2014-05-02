using DBFluteRuntime.JavaLike.Helper;
using System;

namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// [java]Integer - [C#]int? 関連付け
    /// </summary>
    public sealed class Integer
    {
        // #pending スレッドセーフ化は未対応
        private static readonly JavaBasicValueCache<int?, Integer> _basicValue = new JavaBasicValueCache<int?, Integer>();

        /// <summary>
        /// 値（書き換え不可）
        /// </summary>
        private readonly int? innerValue;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="initValue">初期化フラグ</param>
        private Integer(int? initValue)
        {
            this.innerValue = initValue;
        }

        /// <summary>
        /// &演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator &(Integer a, Integer b)
        {
            return (a.innerValue & b.innerValue);
        }

        /// <summary>
        /// |演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator |(Integer a, Integer b)
        {
            return (a.innerValue | b.innerValue);
        }

        /// <summary>
        /// +演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator +(Integer a, Integer b)
        {
            _basicValue.throwExIfNull(a, ConstParamName.PARAM_A);
            _basicValue.throwExIfNull(b, ConstParamName.PARAM_B);
            return _basicValue.GetCashedValue(a.innerValue + b.innerValue, HasValue, CreateInstance);
        }

        /// <summary>
        /// -演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator -(Integer a, Integer b)
        {
            _basicValue.throwExIfNull(a, ConstParamName.PARAM_A);
            _basicValue.throwExIfNull(b, ConstParamName.PARAM_B);
            return _basicValue.GetCashedValue(a.innerValue - b.innerValue, HasValue, CreateInstance);
        }

        /// <summary>
        /// *演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator *(Integer a, Integer b)
        {
            _basicValue.throwExIfNull(a, ConstParamName.PARAM_A);
            _basicValue.throwExIfNull(b, ConstParamName.PARAM_B);
            return _basicValue.GetCashedValue(a.innerValue * b.innerValue, HasValue, CreateInstance);
        }

        /// <summary>
        /// /演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator /(Integer a, Integer b)
        {
            _basicValue.throwExIfNull(a, ConstParamName.PARAM_A);
            _basicValue.throwExIfNull(b, ConstParamName.PARAM_B);
            return _basicValue.GetCashedValue(a.innerValue / b.innerValue, HasValue, CreateInstance);
        }

        /// <summary>
        /// インクリメント演算子
        /// </summary>
        /// <returns></returns>
        public static Integer operator ++(Integer i)
        {
            _basicValue.throwExIfNull(i, ConstParamName.PARAM_I);
            return _basicValue.GetCashedValue(i.innerValue + 1, HasValue, CreateInstance);
        }

        /// <summary>
        /// デクリメント演算子
        /// </summary>
        /// <returns></returns>
        public static Integer operator --(Integer i)
        {
            _basicValue.throwExIfNull(i, ConstParamName.PARAM_I);
            return _basicValue.GetCashedValue(i.innerValue - 1, HasValue, CreateInstance);
        }

        /// <summary>
        /// キャスト演算子
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static implicit operator int?(Integer i)
        {
            return i.innerValue;
        }

        /// <summary>
        /// キャスト演算子
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static implicit operator Integer(int? i)
        {
            return _basicValue.GetCashedValue(i, HasValue, CreateInstance);
        }

        /// <summary>
        /// 文字列を数値化する
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Integer valueOf(string s)
        {
            return _basicValue.GetCashedValue(int.Parse(s), HasValue, CreateInstance);
        }

        /// <summary>
        /// 文字列から数値への変換
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public static int parseInt(string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        /// int値を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">内部で保持している値が存在しない場合</exception>
        public int intValue()
        {
            if (innerValue.HasValue)
            {
                return innerValue.Value;
            }
            throw new NullReferenceException("Inner value is null.");
        }

        /// <summary>
        /// 文字列化した場合は実際のフラグを返す
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return innerValue.HasValue ? innerValue.ToString() : "null";
        }

        /// <summary>
        /// 同値か判定
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return !innerValue.HasValue;
            }
            if (obj is int)
            {
                int target = (int)obj;
                if (innerValue.HasValue)
                {
                    return target == innerValue.Value;    
                }
                return false;
            }
            if (obj is int?)
            {
                int? target = (int?)obj;
                return (target == innerValue);
            }
            if (obj is Integer)
            {
                // 同じ型どうしの比較。nullではない
                Integer target = (Integer)obj;
                return (target.innerValue == this.innerValue);
            }

            return false;
        }

        /// <summary>
        /// ハッシュ値を返す
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 値有無チェック
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static bool HasValue(int? i)
        {
            return i.HasValue;
        }

        /// <summary>
        /// インスタンス生成
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static Integer CreateInstance(int? i)
        {
            return new Integer(i);
        }
    }
}
