using DBFlute.JavaLike.Sql;
using DBFluteRuntimeTest.TestDB;
using NUnit.Framework;
using Connection = System.Data.IDbConnection;

namespace DBFluteRuntimeTest.JavaLike.Sql
{
    /// <summary>
    /// DataSourceクラステスト
    /// </summary>
    [TestFixture]
    public class DataSourceTest
    {
        /// <summary>
        /// 正常にConnectionインスタンスを取得できるか確認
        /// </summary>
        [Test]
        public void TestGetConnection()
        {
            TestDbProvider provider = TestDbProvider.GetInstance();
            DataSource ds = new DataSource();
            ds.ConnectionString = provider.GetConnectionString();
            ds.ConnectionTypeName = provider.GetConnectionTypeName();
            Connection connection = ds.getConnection();
            Assert.IsNotNull(connection);
        }
    }
}
