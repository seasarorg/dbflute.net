using DBFluteRuntime.JavaLike.Sql;
using DBFluteRuntimeTest.TestDB;
using System;
using Connection = System.Data.IDbConnection;

namespace DBFluteRuntimeTest
{
    /// <summary>
    /// DBFluteRuntimeテストユーティリティクラス
    /// </summary>
    public static class DBFluteRuntimeTestUtils
    {
        /// <summary>
        /// クエリの実行
        /// </summary>
        /// <param name="invoker"></param>
        public static void ExecuteQuery(Action<Connection> invoker)
        {
            // ## Arrange ##
            DataSource ds = TestDbProvider.GetInstance().GetDataSource();
            Connection cn = ds.getConnection();
            cn.Open();
            try
            {
                invoker(cn);
            }
            finally
            {
                cn.close();
            }
        }
    }
}
