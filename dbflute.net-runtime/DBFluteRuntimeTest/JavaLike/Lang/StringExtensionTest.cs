using DBFlute.JavaLike.Lang;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Lang
{
    /// <summary>
    /// StringExtensionクラステスト
    /// </summary>
    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void TestTrim()
        {
            const string F_SPACE = " hoge";
            const string R_SPACE = "hoge ";
            const string W_SPACE = " hoge ";
            const string N_SPACE = "hoge";

            Assert.AreEqual(F_SPACE.Trim(), F_SPACE.trim());
            Assert.AreEqual(R_SPACE.Trim(), R_SPACE.trim());
            Assert.AreEqual(W_SPACE.Trim(), W_SPACE.trim());
            Assert.AreEqual(N_SPACE.Trim(), N_SPACE.trim());
        }

        [Test]
        public void TestLength()
        {
            const string ACTUAL = "Hoge";

            Assert.AreEqual(ACTUAL.Length, ACTUAL.length());
        }

        [Test]
        public void TestValueOfInt()
        {
            const int ACTUAL = 123;
            const string EXPECT = "123";

            Assert.AreEqual(EXPECT, StringExtension.valueOf(ACTUAL));
        }

        [Test]
        public void TestValueOfChar()
        {
            const char ACTUAL = 'a';
            const string EXPECT = "a";

            Assert.AreEqual(EXPECT, StringExtension.valueOf(ACTUAL));
        }

        [Test]
        public void TestValueOfBoolean()
        {
            const bool ACTUAL_T = true;
            const bool ACTUAL_F = false;
            const string EXPECT_T = "true";
            const string EXPECT_F = "false";

            Assert.AreEqual(EXPECT_T, StringExtension.valueOf(ACTUAL_T));
            Assert.AreEqual(EXPECT_F, StringExtension.valueOf(ACTUAL_F));
        }
    }
}
