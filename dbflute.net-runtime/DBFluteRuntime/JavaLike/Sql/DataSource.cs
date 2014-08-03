using DBFluteRuntime.JavaLike.Helper;
using Connection = System.Data.IDbConnection;

namespace DBFluteRuntime.JavaLike.Sql
{
// #pending 未実装
    /// <summary>
    /// [Java]DataSource 
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        public string ConnectionString { get; set; }

        public string ConnectionTypeName { get; set; }

        public Connection getConnection()
        {
            // #pending 接続文字列も設定
            var connection = (Connection)ClassUtils.createInstance(ConnectionTypeName);
            connection.ConnectionString = ConnectionString;
            return connection;
        }
    }
}
