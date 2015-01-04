using DBFlute.JavaLike.Lang;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Lang
{
    /// <summary>
    /// booleanクラステスト
    /// </summary>
    [TestFixture]
    public class booleanTest
    {
        public string aaa = "hoge";
        /// <summary>
        /// bool型「true」と同じ動きをするか確認
        /// </summary>
        [Test]
        public void TestTrue()
        {
            boolean actual = boolean.BOOLEAN_TRUE;
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// bool型「false」と同じ動きをするか確認
        /// </summary>
        [Test]
        public void TestFalse()
        {
            boolean actual = boolean.BOOLEAN_FALSE;
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// &&演算子に対して正常な動きをするか確認
        /// </summary>
        [Test]
        public void TestAnd()
        {
            // ## Arrange ##
            boolean actualT = true;
            boolean actualF = false;

            // ## Act & Assert ##
            Assert.IsTrue(actualT && actualT);
            Assert.IsFalse(actualF && actualT);
            Assert.IsFalse(actualT && actualF);
            Assert.IsFalse(actualF && actualF);
        }

        /// <summary>
        /// ||演算子に対して正常な動きをするか確認
        /// </summary>
        [Test]
        public void TestOr()
        {
            // ## Arrange ##
            boolean actualT = true;
            boolean actualF = false;

            // ## Act & Assert ##
            Assert.IsTrue(actualT || actualT);
            Assert.IsTrue(actualF || actualT);
            Assert.IsTrue(actualT || actualF);
            Assert.IsFalse(actualF || actualF);
        }

        /// <summary>
        /// ==演算子に対して正常な動きをするか確認
        /// </summary>
        [Test]
        public void TestEqualEqual()
        {
            // ## Arrange ##
            boolean actualT = true;
            boolean actualF = false;

            // ## Act & Assert ##
            Assert.IsTrue(actualT == true);
            Assert.IsTrue(actualF == false);
        }
    }
}
