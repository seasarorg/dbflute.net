using DBFlute.JavaLike.IO;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using BufferedReader = System.IO.StreamReader;

namespace DBFluteRuntimeTest.JavaLike.IO
{
    [TestFixture]
    public class BufferedReaderTest
    {
        private const string TEST_LINE_1 = "Test";
        private const string TEST_LINE_2 = "あいうえお";
        private const string TEST_LINE_3 = "#$%^-+=@";

        // Test ============================================================================

        [Test]
        public void TestReadLine()
        {
            string testFilePath = GetTestFilePath();
            try
            {
                // ## Arrange ##
                CreateData(testFilePath);

                using (BufferedReader reader = System.IO.File.OpenText(testFilePath))
                {
                    Assert.AreEqual(TEST_LINE_1, reader.readLine());
                    Assert.AreEqual(TEST_LINE_2, reader.readLine());
                    Assert.AreEqual(TEST_LINE_3, reader.readLine());
                }
            } 
            finally
            {
                if (System.IO.File.Exists(testFilePath))
                {
                    System.IO.File.Delete(testFilePath);
                }
            }
        }

        [Test]
        public void TestRead()
        {
            string testFilePath = GetTestFilePath();
            try
            {
                // ## Arrange ##
                const int FIRST_BUF_SIZE = 5;
                const int SECOND_BUF_SIZE = 3;
                CreateData(testFilePath);

                char[] buf1 = new char[FIRST_BUF_SIZE];
                char[] buf2 = new char[SECOND_BUF_SIZE];
                using (BufferedReader reader = System.IO.File.OpenText(testFilePath))
                {
                    reader.read(buf1);
                    reader.read(buf2);
                }

                string EXPECT_STR = TEST_LINE_1 + Environment.NewLine + TEST_LINE_2;
                Assert.AreEqual(EXPECT_STR.Substring(0, FIRST_BUF_SIZE), new string(buf1));
                Assert.AreEqual(EXPECT_STR.Substring(FIRST_BUF_SIZE, SECOND_BUF_SIZE), new string(buf2));
            }
            finally
            {
                if (System.IO.File.Exists(testFilePath))
                {
                    System.IO.File.Delete(testFilePath);
                }
            }
        }

        private string GetTestFilePath()
        {
            TestContext context = TestContext.CurrentContext;
            return Path.Combine(new string[] { context.TestDirectory, "TestReadLineResource.txt" });
        }

        private void CreateData(string testFilePath)
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(TEST_LINE_1);
            b.AppendLine(TEST_LINE_2);
            b.AppendLine(TEST_LINE_3);
            System.IO.File.WriteAllText(testFilePath, b.ToString());
        }
    }
}
