using System.Data;

namespace DBFlute.JavaLike.Sql
{
    /// <summary>
    /// [Java]Statement
    /// </summary>
    public class Statement
    {
        protected const int NO_SET = 0;
        private readonly IDbConnection _connection;
        private int _timeout = NO_SET;
        private int _fetchSize = NO_SET;
        private int _maxRows = NO_SET;
        private int _updatedCount = 0;

        public Statement(IDbConnection connection)
        {
            _connection = connection;
        }

        public virtual void close()
        {
            _connection.close();
        }

        public virtual void setQueryTimeout(int seconds)
        {
            _timeout = seconds;
        }

        public virtual void setFetchSize(int size)
        {
            _fetchSize = size;
        }

        public virtual void setMaxRows(int max)
        {
            _maxRows = max;
        }

        public virtual ResultSet executeQuery(string sql)
        {
            return executeQuery(createCommand(sql));
        }

        public virtual int executeUpdate(string sql)
        {
            return executeUpdate(createCommand(sql));
        }

        public virtual int getUpdateCount()
        {
            return _updatedCount;
        }

        #region 補助メソッド（継承可）
        protected virtual ResultSet executeQuery(IDbCommand command)
        {
            IDataReader reader = command.ExecuteReader();
            ResultSet result = new ResultSet(reader);
            if (_fetchSize != NO_SET)
            {
                result.setFetchSize(_fetchSize);
            }

            if (_maxRows != NO_SET)
            {
                result.setMaxRows(_maxRows);
            }

            return new ResultSet(reader);
        }

        protected virtual int executeUpdate(IDbCommand command)
        {
            _updatedCount = command.ExecuteNonQuery();
            return _updatedCount;
        }

        protected virtual void addUpdatedCount(int updatedCount)
        {
            _updatedCount = _updatedCount + updatedCount;
        }

        #endregion

        #region 補助メソッド

        private IDbCommand createCommand(string sql)
        {
            IDbCommand command = _connection.CreateCommand();
            command.CommandText = sql;
            if (_timeout != NO_SET)
            {
                command.CommandTimeout = _timeout;
            }
            return command;
        }

        #endregion
    }
}
