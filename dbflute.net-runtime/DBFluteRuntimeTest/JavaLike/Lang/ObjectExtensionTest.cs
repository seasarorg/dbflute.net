using DBFlute.JavaLike.Lang;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Lang
{
    /// <summary>
    /// ObjectExtensionテスト
    /// </summary>
    [TestFixture]
    public class ObjectExtensionTest
    {
        [Test]
        public void TestToString()
        {
            object actual = "dbflute";
            Assert.AreEqual(actual.ToString(), actual.toString());
        }

        [Test]
        public void TestGetClass()
        {
            object actual = "dbflute";
            Assert.AreEqual(actual.GetType(), actual.getClass());
        }

        [Test]
        public void TestHashCode()
        {
            object actual = "dbflute";
            Assert.AreEqual(actual.GetHashCode(), actual.hashCode());
        }

        [Test]
        public void TestEquals()
        {
            object actualA = "dbflute";
            object actualB = "dbflute";
            object actualX = "runtime";

            Assert.AreEqual(actualA.Equals(actualB), actualA.equals(actualB));
            Assert.AreEqual(actualA.Equals(actualX), actualA.equals(actualX));
        }
    }
}
