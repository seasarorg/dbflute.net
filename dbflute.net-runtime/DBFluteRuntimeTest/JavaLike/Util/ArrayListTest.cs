using DBFlute.JavaLike.Util;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Util
{
    /// <summary>
    /// [Java]ArrayListテストクラス
    /// </summary>
    [TestFixture]
    public class ArrayListTest
    {
        /// <summary>
        /// add, get, sizeメソッドのテスト
        /// </summary>
        [Test]
        public void TestAddAndGetAndSize()
        {
            // ## Arrange ##
            ArrayList<string> actual = new ArrayList<string>();
            const string TEST_ITEM = "dbflute";

            // ## Act ##
            bool result = actual.add(TEST_ITEM);
            string additionalItem = actual.get(actual.size() - 1);

            // ## Assert ##
            Assert.IsTrue(result, "必ずtrueになる想定");
            Assert.AreEqual(TEST_ITEM, additionalItem);
        }

        [Test]
        public void TestAddAll()
        {
            // ## Arrange ##
            ArrayList<int> actual1 = new ArrayList<int>();
            actual1.add(1);
            ArrayList<int> actual2 = new ArrayList<int>();
            actual2.add(2);
            actual2.add(3);
            int[] expect = { 1, 2, 3 };

            // ## Act ##
            bool result = actual1.addAll(actual2);

            // ## Assert ##
            Assert.IsTrue(result);
            for (int i = 0; i < expect.Length; i++)
            {
                Assert.AreEqual(expect[i], actual1.get(i));
            }
        }

        [Test]
        public void TestConstructor()
        {
            // ## Arrange ##
            ArrayList<int> expect = new ArrayList<int>();
            expect.add(4);
            expect.add(5);
            expect.add(6);

            // ## Act ##
            ArrayList<int> actual = new ArrayList<int>(expect);

            // ## Assert ##
            for(int i = 0; i < expect.size(); i++)
            {
                Assert.AreEqual(expect.get(i), actual.get(i));
            }
        }

        [Test]
        public void TestSet()
        {
            // ## Arrange ##
            const long BEFORE = long.MinValue;
            const long EXPECT = long.MaxValue;
            ArrayList<long> actualList = new ArrayList<long>();
            actualList.add(BEFORE);
            int expectSize = actualList.size();

            // ## Act ##
            actualList.set(actualList.size() - 1, EXPECT);

            // ## Assert ##
            Assert.AreEqual(EXPECT, actualList.get(actualList.size() - 1));
            Assert.AreEqual(expectSize, actualList.size());
        }

        [Test]
        public void TestRemoveByIndex()
        {
            // ## Arrange ##
            ArrayList<int> actualList = new ArrayList<int>();
            const int TEST_ITEM = 1;
            actualList.add(TEST_ITEM);
            int beforeSize = actualList.size();

            // ## Act ##
            int removedItem = actualList.remove(0);

            // ## Assert ##
            Assert.AreEqual(TEST_ITEM, removedItem);
            Assert.AreEqual(beforeSize - 1, actualList.size());
        }

        [Test]
        public void TestRemoveByElement()
        {
            // ## Arrange ##
            ArrayList<string> actualList = new ArrayList<string>();
            const string TEST_ITEM1 = "dbflute";
            const string TEST_ITEM2 = "runtime";
            actualList.add(TEST_ITEM1);
            actualList.add(TEST_ITEM2);
            int beforeSize = actualList.size();

            // ## Act ##
            bool result = actualList.remove(TEST_ITEM1);

            // ## Assert ##
            Assert.IsTrue(result);
            Assert.AreEqual(beforeSize - 1, actualList.size());
            Assert.AreEqual(TEST_ITEM2, actualList.get(actualList.size() - 1));
        }

        [Test]
        public void TestClear()
        {
            // ## Arrange ##
            ArrayList<string> actualList = new ArrayList<string>();
            const string TEST_ITEM1 = "dbflute";
            const string TEST_ITEM2 = "runtime";
            actualList.add(TEST_ITEM1);
            actualList.add(TEST_ITEM2);

            // ## Act ##
            actualList.clear();

            // ## Assert ##
            Assert.AreEqual(0, actualList.size());
        }

        [Test]
        public void TestIsEmpty()
        {
            // ## Arrange ##
            ArrayList<string> actualEmpty = new ArrayList<string>();
            ArrayList<string> actualNotEmpty = new ArrayList<string>();
            actualNotEmpty.add("hoge");

            // ## Act / Assert ##
            Assert.IsTrue(actualEmpty.isEmpty());
            Assert.IsFalse(actualNotEmpty.isEmpty());
        }

        [Test]
        public void TestIterator()
        {
            // ## Arrange ##
            ArrayList<string> expectList = new ArrayList<string>();
            expectList.add("dbflute");
            expectList.add("runtime");
            expectList.add("test");

            // ## Act ##
            Iterator<string> it = expectList.iterator();

            // ## Assert ##
            int i = 0;
            while(it.hasNext())
            {
                string actual = it.next();
                Assert.AreEqual(expectList.get(i), actual);
                i++;
            }
        }

        [Test]
        public void TestToString()
        {
            // ## Arrange ##
            ArrayList<string> expectList = new ArrayList<string>();
            expectList.add("dbflute");
            expectList.add("runtime");
            expectList.add("test");
            const string EXPECT = "{dbflute, runtime, test}";

            // ## Act ##
            string actual = expectList.ToString();

            // ## Assert ##
            Assert.AreEqual(EXPECT, actual);
        }
    }
}
