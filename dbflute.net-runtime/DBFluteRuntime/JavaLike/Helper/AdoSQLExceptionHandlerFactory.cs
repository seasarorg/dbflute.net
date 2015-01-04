using DBFlute.JavaLike.Lang;
using System;
using System.Collections.Generic;

namespace DBFlute.JavaLike.Helper
{
    /// <summary>
    /// プロバイダごとの例外の違いを吸収するためのファクトリクラス
    /// #pending 各プロバイダごとの処理は未実装
    /// </summary>
    public class AdoSQLExceptionHandlerFactory
    {
        /// <summary>
        /// プロバイダごとのSQLExceptionハンドラコレクション
        /// </summary>
        private readonly IDictionary<string, AdoSQLExceptionHandler> _sqlExceptionHandlers = createSqlExceptionHandlers();

        /// <summary>
        /// ADO.NET共通SQL例外処理の取得
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public AdoSQLExceptionHandler getAdoSqlExceptionHandler(string typeName)
        {
            if (_sqlExceptionHandlers.ContainsKey(typeName))
            {
                return _sqlExceptionHandlers[typeName];
            }
            return null;
        }

        /// <summary>
        /// プロバイダごとのSQLExceptionハンドラ生成
        /// </summary>
        /// <returns></returns>
        private static IDictionary<string, AdoSQLExceptionHandler> createSqlExceptionHandlers()
        {
            var exceptions = new Dictionary<string, AdoSQLExceptionHandler>();
            // #pending 型名をキーに各DB例外クラス用の実装を設定

            return exceptions;
        }
    }

    /// <summary>
    /// java.sql.SQLException対応処理インターフェース
    /// </summary>
    public interface AdoSQLExceptionHandler
    {
        Integer getErrorCode(SystemException ex);
        SystemException getNextException(SystemException ex);
        string getSQLState(SystemException ex);
    }
}
