using DBFluteRuntime.JavaLike.Util;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Util
{
    /// <summary>
    /// [Java]HashSetテストクラス
    /// </summary>
    [TestFixture]
    public class HashSetTest
    {
        /// <summary>
        /// add, sizeメソッドのテスト
        /// </summary>
        [Test]
        public void TestAddAndSize()
        {
            // ## Arrange ##
            HashSet<string> actual = new HashSet<string>();
            const string TEST_ITEM = "dbflute";
            int beforeSize = actual.size();

            // ## Act ##
            bool result = actual.add(TEST_ITEM);

            // ## Assert ##
            Assert.IsTrue(result, "必ずtrueになる想定");
            Assert.AreEqual(beforeSize + 1, actual.size());
        }

        [Test]
        public void TestAddDupuricated()
        {
            // ## Arrange ##
            HashSet<string> actual = new HashSet<string>();
            const string TEST_ITEM1 = "dbflute";
            const string TEST_ITEM2 = TEST_ITEM1; // 重複している要素
            actual.add(TEST_ITEM1);
            int expectSize = actual.size();

            // ## Act ##
            bool result = actual.add(TEST_ITEM2);

            // ## Assert ##
            Assert.IsFalse(result);
            Assert.AreEqual(expectSize, actual.size(), "重複している要素は追加されない");
        }

        [Test]
        public void TestAddAllAndContains()
        {
            // ## Arrange ##
            HashSet<int> actual1 = new HashSet<int>();
            actual1.add(1);
            HashSet<int> actual2 = new HashSet<int>();
            actual2.add(2);
            actual2.add(3);
            int[] expect = { 1, 2, 3 };

            // ## Act ##
            bool result = actual1.addAll(actual2);

            // ## Assert ##
            Assert.IsTrue(result);
            for (int i = 0; i < expect.Length; i++)
            {
                Assert.IsTrue(actual1.contains(expect[i]));
            }
            Assert.IsFalse(actual2.contains(1));
        }

        [Test]
        public void TestRemoveByElement()
        {
            // ## Arrange ##
            HashSet<string> actualSet = new HashSet<string>();
            const string TEST_ITEM1 = "dbflute";
            const string TEST_ITEM2 = "runtime";
            actualSet.add(TEST_ITEM1);
            actualSet.add(TEST_ITEM2);
            int beforeSize = actualSet.size();

            // ## Act ##
            bool result = actualSet.remove(TEST_ITEM1);

            // ## Assert ##
            Assert.IsTrue(result);
            Assert.AreEqual(beforeSize - 1, actualSet.size());
            Assert.IsTrue(actualSet.containsAsNg(TEST_ITEM2));
            Assert.IsFalse(actualSet.containsAsNg(TEST_ITEM1));
        }

        [Test]
        public void TestClear()
        {
            // ## Arrange ##
            HashSet<string> actualSet = new HashSet<string>();
            const string TEST_ITEM1 = "dbflute";
            const string TEST_ITEM2 = "runtime";
            actualSet.add(TEST_ITEM1);
            actualSet.add(TEST_ITEM2);

            // ## Act ##
            actualSet.clear();

            // ## Assert ##
            Assert.AreEqual(0, actualSet.size());
        }

        [Test]
        public void TestIsEmpty()
        {
            // ## Arrange ##
            HashSet<string> actualEmpty = new HashSet<string>();
            HashSet<string> actualNotEmpty = new HashSet<string>();
            actualNotEmpty.add("hoge");

            // ## Act / Assert ##
            Assert.IsTrue(actualEmpty.isEmpty());
            Assert.IsFalse(actualNotEmpty.isEmpty());
        }

        [Test]
        public void TestIterator()
        {
            // ## Arrange ##
            HashSet<string> expectSet = new HashSet<string>();
            expectSet.add("dbflute");
            expectSet.add("runtime");
            expectSet.add("test");

            // ## Act ##
            Iterator<string> it = expectSet.iterator();

            // ## Assert ##
            int i = 0;
            while(it.hasNext())
            {
                string actual = it.next();
                Assert.IsTrue(expectSet.contains(actual));
                i++;
            }
        }

        [Test]
        public void TestToString()
        {
            // ## Arrange ##
            HashSet<string> expectSet = new HashSet<string>();
            expectSet.add("dbflute");
            expectSet.add("runtime");
            expectSet.add("test");
            const string EXPECT = "{dbflute, runtime, test}";

            // ## Act ##
            string actual = expectSet.ToString();

            // ## Assert ##
            Assert.AreEqual(EXPECT, actual);
        }
    }
}
