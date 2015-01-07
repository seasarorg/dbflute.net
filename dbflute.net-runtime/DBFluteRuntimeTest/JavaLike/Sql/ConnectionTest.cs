using DBFlute.JavaLike.Sql;
using NUnit.Framework;
using DBFlute.JavaLike.Extensions;
using Connection = System.Data.IDbConnection;

namespace DBFluteRuntimeTest.JavaLike.Sql
{
    /// <summary>
    /// Connection(IDbConnection拡張）テスト
    /// </summary>
    [TestFixture]
    public class ConnectionTest
    {
        /// <summary>
        /// Statement生成
        /// </summary>
        [Test]
        public void TestCreateStatement()
        {
            DBFluteRuntimeTestUtils.ExecuteQuery(cn =>
            {
                var actual = cn.createStatement();
                Assert.IsNotNull(actual);
                Assert.AreEqual(typeof(Statement), actual.GetType());
            });
        }

        /// <summary>
        /// PreparedStatement生成
        /// </summary>
        [Test]
        public void TestPreparedStatement()
        {
            DBFluteRuntimeTestUtils.ExecuteQuery(cn => {
                var actual = cn.prepareStatement("SELECT * FROM MEMBER_ID=?");
                Assert.IsNotNull(actual);
                Assert.AreEqual(typeof(PreparedStatement), actual.GetType());
            });
        }
    }
}
