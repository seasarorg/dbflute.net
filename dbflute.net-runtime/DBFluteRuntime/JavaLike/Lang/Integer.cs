using System;
using System.Collections.Generic;

namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// [java]Integer - [C#]int? 関連付け
    /// </summary>
    public sealed class Integer
    {
        /// <summary>
        /// 例外メッセージ用パラメータ名
        /// </summary>
        private const string PARAM_A = "a";

        /// <summary>
        /// 例外メッセージ用パラメータ名
        /// </summary>
        private const string PARAM_B = "b";

        /// <summary>
        /// 例外メッセージ用パラメータ名
        /// </summary>
        private const string PARAM_I = "i";

        /// <summary>
        /// 一度生成したIntegerインスタンスはキャッシュしておく
        /// </summary>
        private static readonly IDictionary<int?, Integer> CASHED_INT = new Dictionary<int?, Integer>();

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
            throwExIfNull(a, PARAM_A);
            throwExIfNull(b, PARAM_B);
            return GetCashedInt(a.innerValue + b.innerValue);
        }

        /// <summary>
        /// -演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator -(Integer a, Integer b)
        {
            throwExIfNull(a, PARAM_A);
            throwExIfNull(b, PARAM_B);
            return GetCashedInt(a.innerValue - b.innerValue);
        }

        /// <summary>
        /// *演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator *(Integer a, Integer b)
        {
            throwExIfNull(a, PARAM_A);
            throwExIfNull(b, PARAM_B);
            return GetCashedInt(a.innerValue * b.innerValue);
        }

        /// <summary>
        /// /演算子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer operator /(Integer a, Integer b)
        {
            throwExIfNull(a, PARAM_A);
            throwExIfNull(b, PARAM_B);
            return GetCashedInt(a.innerValue / b.innerValue);
        }

        /// <summary>
        /// インクリメント演算子
        /// </summary>
        /// <returns></returns>
        public static Integer operator ++(Integer i)
        {
            throwExIfNull(i, PARAM_I);
            return GetCashedInt(i.innerValue + 1);
        }

        /// <summary>
        /// デクリメント演算子
        /// </summary>
        /// <returns></returns>
        public static Integer operator --(Integer i)
        {
            throwExIfNull(i, PARAM_I);
            return GetCashedInt(i.innerValue - 1);
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
            return GetCashedInt(i);
        }

        /// <summary>
        /// 文字列を数値化する
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Integer valueOf(string s)
        {
            return GetCashedInt(int.Parse(s));
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
        /// 値有無チェック（値が設定されていなければNullReferenceException）
        /// </summary>
        /// <param name="i">チェック値</param>
        /// <param name="parameterName">パラメータ名</param>
        /// <exception cref="NullReferenceException">値が設定されていない場合の例外</exception>
        private static void throwExIfNull(Integer i, string parameterName)
        {
            if (i == null)
            {
                throw new NullReferenceException(string.Format("Parameter [{0}] is null.", parameterName));
            }

            if (!i.innerValue.HasValue)
	        {
                throw new NullReferenceException(string.Format("Parameter [{0}] has no value.", parameterName));
	        }
        }

        /// <summary>
        /// キャッシュされたIntegerインスタンスの取得（未キャッシュの場合はキャッシュして返す）
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static Integer GetCashedInt(int? i)
        {
            if (!i.HasValue)
            {
                return null;
            }

            if (!CASHED_INT.ContainsKey(i))
            {
                CASHED_INT[i] = new Integer(i);
            }
            return CASHED_INT[i];
        }
    }
}
