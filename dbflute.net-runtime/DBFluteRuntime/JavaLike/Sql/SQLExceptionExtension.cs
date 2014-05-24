using DBFluteRuntime.JavaLike.Helper;
using DBFluteRuntime.JavaLike.Lang;
using System;

namespace DBFluteRuntime.JavaLike.Sql
{
    /// <summary>
    /// [Java]SQLException([C#]SystemExceptionの拡張）
    /// </summary>
    public static class SQLExceptionExtension
    {
        private static readonly AdoSQLExceptionHandlerFactory _exceptionFactory = new AdoSQLExceptionHandlerFactory();

        /// <summary>
        /// エラーコードの取得
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Integer getErrorCode(this SystemException ex)
        {
            return executeExceptionMethod(ex, adoEx => adoEx.getErrorCode(ex));
        }

        /// <summary>
        /// 次の例外を取得
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static SystemException getNextException(this SystemException ex)
        {
            return executeExceptionMethod(ex, adoEx => adoEx.getNextException(ex));
        }

        /// <summary>
        /// SQLステートの取得
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string getSQLState(this SystemException ex)
        {
            return executeExceptionMethod(ex, adoEx => adoEx.getSQLState(ex));
        }

        /// <summary>
        /// 例外処理実行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ex"></param>
        /// <param name="defaultValue"></param>
        /// <param name="invoker"></param>
        /// <returns></returns>
        private static T executeExceptionMethod<T>(SystemException ex, Func<AdoSQLExceptionHandler, T> invoker)
        {
            var adoSqlEx = _exceptionFactory.getAdoSqlExceptionHandler(ex.GetType().FullName);
            if (adoSqlEx != null)
            {
                return invoker(adoSqlEx);
            }
            return default(T);
        }
    }
}
