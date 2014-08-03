
using DBFluteRuntime.JavaLike.Sql;
using System;

namespace DBFluteRuntimeTest.TestDB
{
    /// <summary>
    /// テスト用のデータベース関連情報提供クラス
    /// </summary>
    public abstract class TestDbProvider
    {
        /// <summary>
        /// 使用するDBプロバイダ
        /// </summary>
        private static readonly TestDbProvider _provider = new MySqlProvider();

        public static TestDbProvider GetInstance()
        {
            return _provider;
        }

        /// <summary>
        /// Connectionクラス名（名前空間含む）の取得
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectionTypeName();

        /// <summary>
        /// 接続文字列の取得
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectionString();

        /// <summary>
        /// データソースの取得
        /// </summary>
        /// <returns></returns>
        public DataSource GetDataSource()
        {
            DataSource ds = new DataSource();
            ds.ConnectionTypeName = GetConnectionTypeName();
            ds.ConnectionString = GetConnectionString();
            return ds;
        }

        static TestDbProvider()
        {
            try
            {
                TestEnvironment.LoadLibrary();
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
