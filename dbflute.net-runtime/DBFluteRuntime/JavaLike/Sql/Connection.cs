using System;

namespace DBFluteRuntime.JavaLike.Sql
{
    // #pending とりあえず必要なメソッドだけ。中身は順次実装
    /// <summary>
    /// [Java]Connection
    /// </summary>
    public class Connection
    {
        public DatabaseMetaData getMetaData()
        {
            throw new NotSupportedException();
        }

        public void close()
        {
            throw new NotSupportedException();
        }

        public CallableStatement prepareCall(string sql)
        {
            throw new NotSupportedException();
        }

        public PreparedStatement prepareStatement(string sql)
        {
            throw new NotSupportedException();
        }

        public Statement createStatement()
        {
            throw new NotSupportedException();
        }
    }
}
