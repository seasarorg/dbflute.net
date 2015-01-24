using DBFlute.JavaLike.IO;
using DBFlute.JavaLike.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using boolean = System.Boolean;

namespace DBFlute.JavaLike.Sql
{
    /// <summary>
    /// [Java]PreparedStatement
    /// </summary>
    public class PreparedStatement : Statement
    {
        private readonly Regex _regParameter = new Regex("\\?");
        private readonly IDbCommand _command;
        private readonly int _parameterCount;
        private int _batchCount = NO_SET;
        private IList<IDbDataParameter[]> _parameters = new List<IDbDataParameter[]>();

        public PreparedStatement(IDbConnection connection) : base(connection)
        {
            throw new NotSupportedException("Please use another constructor.");
        }

        public PreparedStatement(string sql, IDbConnection connection) : base(connection)
        {
            _parameterCount = getParameterCount(sql);
            _command = connection.CreateCommand();
            _command.CommandText = sql;
            _command.Prepare();
        }

        public ResultSet executeQuery()
        {
            return executeQuery(_command);
        }

        public int executeUpdate()
        {
            return executeUpdate(_command);
        }

        public int[] executeBatch()
        {
            int[] retValues = new int[_parameters.Count];
            for(int i = 0; i < _parameters.Count; i++)
            {
                IDbDataParameter[] sqlParams = _parameters[i];
                foreach(IDbDataParameter p in sqlParams)
                {
                    _command.Parameters.Add(p);
                }
                retValues[i] = _command.ExecuteNonQuery();
                addUpdatedCount(retValues[i]);
                _command.Parameters.Clear();
            }
            return retValues;
        }

        public void addBatch()
        {
            _batchCount++;
        }

        public void setBigDecimal(int parameterIndex, BigDecimal x)
        {
            setValue(parameterIndex, DbType.Decimal, x);
        }

        public void setBinaryStream(int parameterIndex, InputStream x, int length)
        {
            // #pending 該当する.NETデータプロバイダ DbTypeがない（setBinaryStream)
            throw new NotSupportedException();
        }

        public void setObject(int parameterIndex, object x)
        {
            setValue(parameterIndex, DbType.Object, x);
        }

        public void setBoolean(int parameterIndex, boolean x)
        {
            setValue(parameterIndex, DbType.Boolean, x);
        }

        public void setByte(int parameterIndex, byte x)
        {
            setValue(parameterIndex, DbType.Byte, x);
        }

        public void setString(int parameterIndex, string x)
        {
            setValue(parameterIndex, DbType.String, x);
        }

        public void setInt(int parameterIndex, int x)
        {
            setValue(parameterIndex, DbType.Int32, x);
        }

        public void setDouble(int parameterIndex, double x)
        {
            setValue(parameterIndex, DbType.Double, x);
        }

        public void setFloat(int parameterIndex, float x)
        {
            setValue(parameterIndex, DbType.Double, x);
        }

        public void setLong(int parameterIndex, long x)
        {
            setValue(parameterIndex, DbType.UInt64, x);
        }

        public void setShort(int parameterIndex, short x)
        {
            setValue(parameterIndex, DbType.Int16, x);
        }

        public void setDate(int parameterIndex, DateTime x)
        {
            setValue(parameterIndex, DbType.Date, x);
        }

        public void setTimestamp(int parameterIndex, DateTime x)
        {
            setValue(parameterIndex, DbType.DateTime, x);
        }

        public void setTime(int parameterIndex, DateTime x)
        {
            setValue(parameterIndex, DbType.Time, x);
        }

        public void setBlob(int parameterIndex, Blob x)
        {
            setValue(parameterIndex, DbType.Binary, x);
        }

        public void setBytes(int parameterIndex, byte[] x)
        {
            // #pending 該当する.NETデータプロバイダ DbTypeがない（setBytes)
            throw new NotSupportedException();
        }

        public void setNull(int parameterIndex, int sqlType, string typeName)
        {
            setValue(parameterIndex, DbType.Object, DBNull.Value);
        }

        public void setCharacterStream(int parameterIndex, Reader reader, int length)
        {
            // #pending 該当する.NETデータプロバイダ DbTypeがない（setCharacterStream)
            throw new NotSupportedException();
        }

        #region 補助メソッド

        /// <summary>
        /// パラメータ数の取得
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private int getParameterCount(string sql)
        {
            return _regParameter.Matches(sql).Count;
        }

        /// <summary>
        /// SQLパラメータの準備
        /// </summary>
        /// <returns></returns>
        private IDbDataParameter[] prepareParameters()
        {
            while (_parameters.Count <= _batchCount)
            {
                _parameters.Add(new IDbDataParameter[_parameterCount]);
            }
            // 最後のパラメータセットを返す
            return _parameters[_parameters.Count - 1];
        }

        /// <summary>
        /// パラメータの設定
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        private void setValue(int index, DbType dbType, object value)
        {
            IDbDataParameter parameter = _command.CreateParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.DbType = dbType;
            parameter.Value = value;
            prepareParameters()[index - 1] = parameter;
        }

        #endregion
    }
}
