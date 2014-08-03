
namespace DBFluteRuntimeTest.TestDB
{
    public class MySqlProvider : TestDbProvider
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        public const string CONNECTION_STRING = "server=127.0.0.1;port=53306;user id=exampledb; password=exampledb; database=exampledb;";
        public const string CONNECTION_TYPE_NAME = "MySql.Data.MySqlClient.MySqlConnection";

        public override string GetConnectionTypeName()
        {
            return CONNECTION_TYPE_NAME;
        }

        public override string GetConnectionString()
        {
            return CONNECTION_STRING;
        }
    }
}
