
using System;
using System.Reflection;

namespace DBFluteRuntimeTest
{
    /// <summary>
    /// テスト実行用環境定義
    /// </summary>
    public class TestEnvironment
    {
        public static void LoadLibrary()
        {
            // MySQL
            Assembly.LoadFrom("MySql.Data.dll");
        }
    }
}
