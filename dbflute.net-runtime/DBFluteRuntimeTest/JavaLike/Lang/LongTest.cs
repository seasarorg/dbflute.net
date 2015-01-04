using DBFlute.JavaLike.Lang;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Lang
{
    [TestFixture]
    public class LongTest
    {
        [Test]
        public void TestPlus()
        {
            long? TEST_1 = 32;
            long? TEST_2 = 64;
            Long actual1 = TEST_1;
            Long actual2 = TEST_2;
            long? actual = actual1 + actual2;

            Assert.AreEqual(TEST_1 + TEST_2, actual);
            Assert.AreEqual(TEST_1 + actual2, actual1 + TEST_2);
        }

        [Test]
        public void TestMinus()
        {
            long? TEST_1 = 32;
            long? TEST_2 = 64;
            Long actual1 = TEST_1;
            Long actual2 = TEST_2;
            long? actual = actual1 - actual2;

            Assert.AreEqual(TEST_1 - TEST_2, actual);
            Assert.AreEqual(TEST_1 - actual2, actual1 - TEST_2);
        }

        [Test]
        public void TestIncrement()
        {
            Long actual = 1;
            long? expect = 1;

            Assert.IsTrue(actual == expect);
            Assert.IsTrue(actual++ == expect++);
            Assert.IsTrue(actual++ == expect++);
            Assert.IsTrue(++actual == ++expect);
            Assert.IsTrue(++actual == ++expect);
        }

        [Test]
        public void TestDecrement()
        {
            Long actual = 1;
            long? expect = 1;

            Assert.IsTrue(actual == expect);
            Assert.IsTrue(actual-- == expect--);
            Assert.IsTrue(actual-- == expect--);
            Assert.IsTrue(--actual == --expect);
            Assert.IsTrue(--actual == --expect);
        }

        [Test]
        public void TestEqualEqual()
        {
            long? TEST_1 = 128;
            long? TEST_2 = 128;
            Long actual1 = TEST_1;
            Long actual2 = TEST_2;

            Assert.AreEqual(TEST_1 == TEST_2, actual1 == actual2);
            Assert.AreEqual(TEST_1 == actual2, actual1 == TEST_2);
        }

        [Test]
        public void TestNotEqual()
        {
            long? TEST_1 = 128;
            long? TEST_2 = 256;
            Long actual1 = TEST_1;
            Long actual2 = TEST_2;

            Assert.AreEqual(TEST_1 != TEST_2, actual1 != actual2);
            Assert.AreEqual(TEST_1 != actual2, actual1 != TEST_2);
        }

        [Test]
        public void TestMultipul()
        {
            long? TEST_1 = 128;
            long? TEST_2 = 128;
            Long actual1 = TEST_1;
            Long actual2 = TEST_2;

            long? actual = actual1 * actual2;

            Assert.AreEqual(TEST_1 * TEST_2, actual);
            Assert.AreEqual(TEST_1 * actual2, actual1 * TEST_2);
        }

        [Test]
        public void TestDivision()
        {
            long? TEST_1 = 128;
            long? TEST_2 = 128;
            Long actual1 = TEST_1;
            Long actual2 = TEST_2;

            long? actual = actual1 / actual2;

            Assert.AreEqual(TEST_1 / TEST_2, actual);
            Assert.AreEqual(TEST_1 / actual2, actual1 / TEST_2);
        }
    }
}
