using System;

namespace DBFluteRuntime.JavaLike.Sql
{
    // #pending とりあえず必要なメソッドだけ。中身は順次実装
    /// <summary>
    /// [Java]CallableStatement
    /// </summary>
    public class CallableStatement : Statement
    {
        public void close()
        {
            throw new NotImplementedException();
        }

        public void setQueryTimeout(int seconds)
        {
            throw new NotImplementedException();
        }

        public void setFetchSize(int size)
        {
            throw new NotImplementedException();
        }

        public void setMaxRows(int max)
        {
            throw new NotImplementedException();
        }

        public ResultSet executeQuery()
        {
            throw new NotImplementedException();
        }

        public int executeUpdate()
        {
            throw new NotImplementedException();
        }

        public int[] executeBatch()
        {
            throw new NotImplementedException();
        }

        public void addBatch()
        {
            throw new NotImplementedException();
        }

        public int getUpdateCount()
        {
            throw new NotImplementedException();
        }

        public void setBigDecimal(int parameterIndex, Math.BigDecimal x)
        {
            throw new NotImplementedException();
        }

        public void setBinaryStream(int parameterIndex, IO.InputStream x, int length)
        {
            throw new NotImplementedException();
        }

        public void setObject(int parameterIndex, object x)
        {
            throw new NotImplementedException();
        }

        public void setBoolean(int parameterIndex, Lang.boolean x)
        {
            throw new NotImplementedException();
        }

        public void setByte(int parameterIndex, byte x)
        {
            throw new NotImplementedException();
        }

        public void setString(int parameterIndex, string x)
        {
            throw new NotImplementedException();
        }

        public void setInt(int parameterIndex, int x)
        {
            throw new NotImplementedException();
        }

        public void setDouble(int parameterIndex, double x)
        {
            throw new NotImplementedException();
        }

        public void setFloat(int parameterIndex, float x)
        {
            throw new NotImplementedException();
        }

        public void setLong(int parameterIndex, long x)
        {
            throw new NotImplementedException();
        }

        public void setShort(int parameterIndex, short x)
        {
            throw new NotImplementedException();
        }

        public void setDate(int parameterIndex, DateTime x)
        {
            throw new NotImplementedException();
        }

        public void setTimestamp(int parameterIndex, DateTime x)
        {
            throw new NotImplementedException();
        }

        public void setTime(int parameterIndex, DateTime x)
        {
            throw new NotImplementedException();
        }

        public void setBlob(int parameterIndex, Blob x)
        {
            throw new NotImplementedException();
        }

        public void setBytes(int parameterIndex, byte[] x)
        {
            throw new NotImplementedException();
        }

        public void setNull(int parameterIndex, int sqlType, string typeName)
        {
            throw new NotImplementedException();
        }

        public void setCharacterStream(int parameterIndex, IO.Reader reader, int length)
        {
            throw new NotImplementedException();
        }
    }
}
