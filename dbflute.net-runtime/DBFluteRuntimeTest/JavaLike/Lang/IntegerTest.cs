using DBFlute.JavaLike.Lang;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Lang
{
    [TestFixture]
    public class IntegerTest
    {
        [Test]
        public void TestPlus()
        {
            int? TEST_1 = 32;
            int? TEST_2 = 64;
            Integer actual1 = TEST_1;
            Integer actual2 = TEST_2;
            int? actual = actual1 + actual2;

            Assert.AreEqual(TEST_1 + TEST_2, actual);
            Assert.AreEqual(TEST_1 + actual2, actual1 + TEST_2);
        }

        [Test]
        public void TestMinus()
        {
            int? TEST_1 = 32;
            int? TEST_2 = 64;
            Integer actual1 = TEST_1;
            Integer actual2 = TEST_2;
            int? actual = actual1 - actual2;

            Assert.AreEqual(TEST_1 - TEST_2, actual);
            Assert.AreEqual(TEST_1 - actual2, actual1 - TEST_2);
        }

        [Test]
        public void TestIncrement()
        {
            Integer actual = 1;
            int? expect = 1;

            Assert.IsTrue(actual == expect);
            Assert.IsTrue(actual++ == expect++);
            Assert.IsTrue(actual++ == expect++);
            Assert.IsTrue(++actual == ++expect);
            Assert.IsTrue(++actual == ++expect);
        }

        [Test]
        public void TestDecrement()
        {
            Integer actual = 1;
            int? expect = 1;

            Assert.IsTrue(actual == expect);
            Assert.IsTrue(actual-- == expect--);
            Assert.IsTrue(actual-- == expect--);
            Assert.IsTrue(--actual == --expect);
            Assert.IsTrue(--actual == --expect);
        }

        [Test]
        public void TestEqualEqual()
        {
            int? TEST_1 = 128;
            int? TEST_2 = 128;
            Integer actual1 = TEST_1;
            Integer actual2 = TEST_2;

            Assert.AreEqual(TEST_1 == TEST_2, actual1 == actual2);
            Assert.AreEqual(TEST_1 == actual2, actual1 == TEST_2);
        }

        [Test]
        public void TestNotEqual()
        {
            int? TEST_1 = 128;
            int? TEST_2 = 256;
            Integer actual1 = TEST_1;
            Integer actual2 = TEST_2;

            Assert.AreEqual(TEST_1 != TEST_2, actual1 != actual2);
            Assert.AreEqual(TEST_1 != actual2, actual1 != TEST_2);
        }

        [Test]
        public void TestMultipul()
        {
            int? TEST_1 = 128;
            int? TEST_2 = 128;
            Integer actual1 = TEST_1;
            Integer actual2 = TEST_2;

            int? actual = actual1 * actual2;

            Assert.AreEqual(TEST_1 * TEST_2, actual);
            Assert.AreEqual(TEST_1 * actual2, actual1 * TEST_2);
        }

        [Test]
        public void TestDivision()
        {
            int? TEST_1 = 128;
            int? TEST_2 = 128;
            Integer actual1 = TEST_1;
            Integer actual2 = TEST_2;

            int? actual = actual1 / actual2;

            Assert.AreEqual(TEST_1 / TEST_2, actual);
            Assert.AreEqual(TEST_1 / actual2, actual1 / TEST_2);
        }
    }
}
