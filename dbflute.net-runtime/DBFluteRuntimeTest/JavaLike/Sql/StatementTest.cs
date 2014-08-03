using DBFluteRuntime.JavaLike.Sql;
using DBFluteRuntimeTest.TestDB;
using NUnit.Framework;
using Connection = System.Data.IDbConnection;

namespace DBFluteRuntimeTest.JavaLike.Sql
{
    [TestFixture]
    public class StatementTest
    {
        [Test]
        public void TestExecuteQuery()
        {
            // ## Arrange ##
            DataSource ds = TestDbProvider.GetInstance().GetDataSource();
            Connection cn = ds.getConnection();
            cn.Open();
            try
            {
                Statement actual = cn.createStatement();

                // ## Act ##
                ResultSet results = actual.executeQuery("SELECT * FROM member");

                // ## Assert ##
                Assert.IsNotNull(results);
            }
            finally
            {
                cn.close();
            }
        }
    }
}
