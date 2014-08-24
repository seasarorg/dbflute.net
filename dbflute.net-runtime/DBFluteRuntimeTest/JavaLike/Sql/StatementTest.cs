using DBFluteRuntime.JavaLike.Sql;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Sql
{
    /// <summary>
    /// Statementテストクラス
    /// </summary>
    [TestFixture]
    public class StatementTest
    {
        /// <summary>
        /// ExecuteQueryメソッドテスト
        /// </summary>
        [Test]
        public void TestExecuteQuery()
        {
            DBFluteRuntimeTestUtils.ExecuteQuery(cn => {
                Statement actual = cn.createStatement();

                // ## Act ##
                ResultSet results = actual.executeQuery("SELECT * FROM member");

                // ## Assert ##
                Assert.IsNotNull(results);

                int count = 0;
                while (results.next())
                {
                    int id = results.getInt(MemberTbl.ID);
                    Assert.Greater(id, 0, id.ToString());
                    count++;
                }
                Assert.IsTrue(count > 0);
            });
        }
    }
}
