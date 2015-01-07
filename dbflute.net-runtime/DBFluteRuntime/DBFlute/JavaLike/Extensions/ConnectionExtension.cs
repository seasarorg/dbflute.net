using DBFlute.JavaLike.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.Extensions
{
    public static class ConnectionExtension
    {
        public static void close(this IDbConnection connection)
        {
            connection.Close();
        }

        public static PreparedStatement prepareStatement(this IDbConnection connection, string sql)
        {
            // TODO 要実装
            throw new NotSupportedException();
        }

        public static Statement createStatement(this IDbConnection connection)
        {
            // TODO 要実装
            throw new NotSupportedException();
        }
    }
}
