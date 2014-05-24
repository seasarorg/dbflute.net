using DBFluteRuntime.JavaLike.IO;
using DBFluteRuntime.JavaLike.Lang;
using DBFluteRuntime.JavaLike.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.Sql
{
    // #pending とりあえず必要なメソッドだけ。中身は順次実装
    /// <summary>
    /// [Java]PreparedStatement
    /// </summary>
    public class PreparedStatement
    {
        public void setQueryTimeout(int seconds)
        {
            throw new NotSupportedException();
        }

        public void setFetchSize(int size)
        {
            throw new NotSupportedException();
        }

        public void setMaxRows(int max)
        {
            throw new NotSupportedException();
        }

        public ResultSet executeQuery()
        {
            throw new NotSupportedException();
        }

        public int executeUpdate()
        {
            throw new NotSupportedException();
        }

        public int[] executeBatch()
        {
            throw new NotSupportedException();
        }

        public void addBatch()
        {
            throw new NotSupportedException();
        }

        public int getUpdateCount()
        {
            throw new NotSupportedException();
        }

        public void setBigDecimal(int parameterIndex, BigDecimal x)
        {
            throw new NotSupportedException();
        }

        public void setBinaryStream(int parameterIndex, InputStream x, int length)
        {
            throw new NotSupportedException();
        }

        public void setObject(int parameterIndex, object x)
        {
            throw new NotSupportedException();
        }

        public void setBoolean(int parameterIndex, boolean x)
        {
            throw new NotSupportedException();
        }

        public void setByte(int parameterIndex, byte x)
        {
            throw new NotSupportedException();
        }

        public void setString(int parameterIndex, string x)
        {
            throw new NotSupportedException();
        }

        public void setInt(int parameterIndex, int x)
        {
            throw new NotSupportedException();
        }

        public void setDouble(int parameterIndex, double x)
        {
            throw new NotSupportedException();
        }

        public void setFloat(int parameterIndex, float x)
        {
            throw new NotSupportedException();
        }

        public void setLong(int parameterIndex, long x)
        {
            throw new NotSupportedException();
        }

        public void setShort(int parameterIndex, short x)
        {
            throw new NotSupportedException();
        }

        public void setDate(int parameterIndex, DateTime x)
        {
            throw new NotSupportedException();
        }

        public void setTimestamp(int parameterIndex, DateTime x)
        {
            throw new NotSupportedException();
        }

        public void setTime(int parameterIndex, DateTime x)
        {
            throw new NotSupportedException();
        }

        public void setBlob(int parameterIndex, Blob x)
        {
            throw new NotSupportedException();
        }

        public void setBytes(int parameterIndex, byte[] x)
        {
            throw new NotSupportedException();
        }

        public void setNull(int parameterIndex, int sqlType, string typeName)
        {
            throw new NotSupportedException();
        }

        public void setCharacterStream(int parameterIndex, Reader reader, int length)
        {
            throw new NotSupportedException();
        }
    }
}
