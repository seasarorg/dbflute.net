using DBFluteRuntime.JavaLike.Util;
using NUnit.Framework;

namespace DBFluteRuntimeTest.JavaLike.Util
{
    /// <summary>
    /// [Java]HashMapテストクラス
    /// </summary>
    [TestFixture]
    public class HashMapTest
    {
        /// <summary>
        /// add, sizeメソッドのテスト
        /// </summary>
        [Test]
        public void TestPutAndSize()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_KEY = "dbflute";
            const string TEST_VALUE = "runtime";
            int beforeSize = actualMap.size();
            
            // ## Act ##
            string actualValue = actualMap.put(TEST_KEY, TEST_VALUE);

            // ## Assert ##
            Assert.AreEqual(default(string), actualValue);
            Assert.AreEqual(TEST_VALUE, actualMap.get(TEST_KEY));
            Assert.AreEqual(beforeSize + 1, actualMap.size());
        }

        [Test]
        public void TestAddDupuricated()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_KEY = "dbflute";
            const string TEST_VALUE1 = "test";
            const string TEST_VALUE2 = "runtime";
            actualMap.put(TEST_KEY, TEST_VALUE1);
            int expectSize = actualMap.size();

            // ## Act ##
            string actual = actualMap.put(TEST_KEY, TEST_VALUE2);   // 同じキー、違う値をput

            // ## Assert ##
            Assert.AreEqual(TEST_VALUE1, actual);
            Assert.AreEqual(TEST_VALUE2, actualMap.get(TEST_KEY), "キーが重複している場合は後がちで置換");
            Assert.AreEqual(expectSize, actualMap.size(), "重複している要素は追加されない");
        }

        [Test]
        public void TestRemoveByElement()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_KEY1 = "dbflute";
            const string TEST_VALUE1 = "value1";
            const string TEST_KEY2 = "runtime";
            const string TEST_VALUE2 = "value2";
            actualMap.put(TEST_KEY1, TEST_VALUE1);
            actualMap.put(TEST_KEY2, TEST_VALUE2);
            int beforeSize = actualMap.size();

            // ## Act ##
            string removedItem = actualMap.remove(TEST_KEY1);

            // ## Assert ##
            Assert.AreEqual(TEST_VALUE1, removedItem);
            Assert.AreEqual(beforeSize - 1, actualMap.size());
            Assert.IsTrue(actualMap.containsKeyAsNg(TEST_KEY2));
            Assert.IsFalse(actualMap.containsKeyAsNg(TEST_KEY1));
        }

        [Test]
        public void TestClear()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_ITEM1 = "dbflute";
            const string TEST_ITEM2 = "runtime";
            actualMap.put(TEST_ITEM1, TEST_ITEM1.ToLower());
            actualMap.put(TEST_ITEM2, TEST_ITEM2.ToLower());

            // ## Act ##
            actualMap.clear();

            // ## Assert ##
            Assert.AreEqual(0, actualMap.size());
        }

        [Test]
        public void TestIsEmpty()
        {
            // ## Arrange ##
            HashMap<string, string> actualEmpty = new HashMap<string, string>();
            HashMap<string, string> actualNotEmpty = new HashMap<string, string>();
            actualNotEmpty.put("hoge", "huga");

            // ## Act / Assert ##
            Assert.IsTrue(actualEmpty.isEmpty());
            Assert.IsFalse(actualNotEmpty.isEmpty());
        }

        [Test]
        public void TestKeySet()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_KEY1 = "dbflute";
            const string TEST_VALUE1 = "value1";
            const string TEST_KEY2 = "runtime";
            const string TEST_VALUE2 = "value2";
            const string TEST_KEY3 = "test";
            const string TEST_VALUE3 = "value3";
            actualMap.put(TEST_KEY1, TEST_VALUE1);
            actualMap.put(TEST_KEY2, TEST_VALUE2);
            actualMap.put(TEST_KEY3, TEST_VALUE3);

            // ## Act ##
            Set<string> actualSet = actualMap.keySet();

            // ## Assert ##
            foreach(string actualKey in actualSet)
            {
                Assert.IsTrue(actualMap.containsKey(actualKey));
            }
        }

        [Test]
        public void TestValues()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_KEY1 = "dbflute";
            const string TEST_VALUE1 = "value1";
            const string TEST_KEY2 = "runtime";
            const string TEST_VALUE2 = "value2";
            const string TEST_KEY3 = "test";
            const string TEST_VALUE3 = "value3";
            actualMap.put(TEST_KEY1, TEST_VALUE1);
            actualMap.put(TEST_KEY2, TEST_VALUE2);
            actualMap.put(TEST_KEY3, TEST_VALUE3);

            // ## Act ##
            Collection<string> actualCollection = actualMap.values();

            // ## Assert ##
            foreach (string actualValue in actualCollection)
            {
                bool isValue = false;
                foreach(string key in actualMap.keySet())
                {
                    if (actualMap.get(key).Equals(actualValue))
                    {
                        isValue = true;
                        break;
                    }
                }
                Assert.IsTrue(isValue);
            }
        }

        [Test]
        public void TestToString()
        {
            // ## Arrange ##
            HashMap<string, string> actualMap = new HashMap<string, string>();
            const string TEST_KEY1 = "dbflute";
            const string TEST_VALUE1 = "value1";
            const string TEST_KEY2 = "runtime";
            const string TEST_VALUE2 = "value2";
            const string TEST_KEY3 = "test";
            const string TEST_VALUE3 = "value3";
            actualMap.put(TEST_KEY1, TEST_VALUE1);
            actualMap.put(TEST_KEY2, TEST_VALUE2);
            actualMap.put(TEST_KEY3, TEST_VALUE3);
            const string EXPECT = "{dbflute=value1, runtime=value2, test=value3}";

            // ## Act ##
            string actual = actualMap.ToString();

            // ## Assert ##
            Assert.AreEqual(EXPECT, actual);
        }
    }
}
