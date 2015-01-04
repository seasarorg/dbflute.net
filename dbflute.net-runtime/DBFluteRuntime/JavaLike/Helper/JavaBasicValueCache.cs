using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Helper
{
    /// <summary>
    /// Java基本型キャッシュクラス
    /// </summary>
    /// <typeparam name="CS">C#型</typeparam>
    /// <typeparam name="J">Java型</typeparam>
    public sealed class JavaBasicValueCache<CS, J>
    {
        /// <summary>
        /// 一度生成したインスタンスはキャッシュしておく
        /// </summary>
        private readonly IDictionary<CS, J> CASHED_VALUE = new Dictionary<CS, J>();

        /// <summary>
        /// 値有無チェック（値が設定されていなければNullReferenceException）
        /// </summary>
        /// <param name="i">チェック値</param>
        /// <param name="parameterName">パラメータ名</param>
        /// <exception cref="NullReferenceException">値が設定されていない場合の例外</exception>
        public void throwExIfNull(J i, string parameterName)
        {
            if (i == null)
            {
                throw new NullReferenceException(string.Format("Parameter [{0}] is null.", parameterName));
            }
        }

        /// 値有無チェック（値が設定されていなければNullReferenceException）
        /// </summary>
        /// <param name="i">チェック値</param>
        /// <param name="parameterName">パラメータ名</param>
        /// <exception cref="NullReferenceException">値が設定されていない場合の例外</exception>
        public void throwExIfNull(CS i, string parameterName, Func<CS, bool> hasValueInvoker)
        {
            if (!hasValueInvoker(i))
            {
                throw new NullReferenceException(string.Format("Parameter [{0}] has no value.", parameterName));
            }
        }

        /// <summary>
        /// キャッシュされたJインスタンスの取得（未キャッシュの場合はキャッシュして返す）
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public J GetCashedValue(CS i, Func<CS, bool> hasValueInvoker, Func<CS, J> createInvoker)
        {
            if (!hasValueInvoker(i))
            {
                return default(J);
            }

            if (!CASHED_VALUE.ContainsKey(i))
            {
                CASHED_VALUE[i] = createInvoker(i);
            }
            return CASHED_VALUE[i];
        }
    }

    /// <summary>
    /// パラメータ名定義定数クラス
    /// </summary>
    internal static class ConstParamName
    {
        /// <summary>
        /// 例外メッセージ用パラメータ名
        /// </summary>
        public const string PARAM_A = "a";

        /// <summary>
        /// 例外メッセージ用パラメータ名
        /// </summary>
        public const string PARAM_B = "b";

        /// <summary>
        /// 例外メッセージ用パラメータ名
        /// </summary>
        public const string PARAM_I = "i";
    }
}
