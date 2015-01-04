using DBFlute.JavaLike.Util;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Util
{
    /// <summary>
    /// [Java]Arraysテストクラス
    /// </summary>
    [TestFixture]
    public class ArraysTest
    {
        [Test]
        public void TestAsList()
        {
            // ## Arrange ##
            string[] expects = { "dbflute", "runtime", "test" };

            // ## Act ##
            List<string> actuals = Arrays.asList(expects);

            // ## Assert ##
            Assert.AreEqual(expects.Length, actuals.size());
            for(int i = 0; i < expects.Length; i++)
            {
                Assert.AreEqual(expects[i], actuals.get(i));
            }
        }

        [Test]
        public void TestEqualsNull()
        {
            Assert.IsTrue(Arrays.equals<string>(null, null));
        }

        [Test]
        public void TestEqualsOneSideNull()
        {
            string[] datas = { "dbflute", "runtime", "test" };
            Assert.IsFalse(Arrays.equals(datas, null));
            Assert.IsFalse(Arrays.equals(null, datas));
        }

        [Test]
        public void TestEquals()
        {
            // ## Arrange ##
            string[] expects = { "dbflute", "runtime", "test" };
            string[] expectsShort = { "dbflute", "runtime" };
            string[] expectsDiff = { "dbflute", "runtime", "Diff" };
            string[] expectsSame = { "dbflute", "runtime", "test" };

            // ## Act / Assert ##
            Assert.IsTrue(Arrays.equals(expects, expects));
            Assert.IsFalse(Arrays.equals(expects, expectsShort));
            Assert.IsFalse(Arrays.equals(expects, expectsDiff));
            Assert.IsTrue(Arrays.equals(expects, expectsSame));
        }

        [Test]
        public void TestSort()
        {
            // ## Arrange ##
            string[] expects = { "dbflute", "runtime", "test" };
            string[] actuals1 = { "test", "dbflute", "runtime" };
            string[] actuals2 = { "dbflute", "runtime", "test" };

            // ## Act ##
            Arrays.sort(actuals1, new ComparatorImpl<string>());
            Arrays.sort(actuals2, new ComparatorImpl<string>());

            // ## Assert ##
            Assert.AreEqual(expects.Length, actuals1.Length);
            for(int i = 0; i < expects.Length; i++)
            {
                Assert.AreEqual(expects[i], actuals1[i]);
            }

            Assert.AreEqual(expects.Length, actuals2.Length);
            for (int i = 0; i < expects.Length; i++)
            {
                Assert.AreEqual(expects[i], actuals2[i]);
            }
        }
    }

    /// <summary>
    /// テスト用比較クラス
    /// </summary>
    /// <typeparam name="?"></typeparam>
    public class ComparatorImpl<T> : Comparator<T>
    {
        public int compare(T o1, T o2)
        {
            if (typeof(T) == typeof(string))
            {
                return o1.ToString().CompareTo(o2.ToString());
            }
            return 0;
        }

        public bool equals(object obj)
        {
            return true;
        }
    }
}
