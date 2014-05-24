using DBFluteRuntime.JavaLike.IO;
using DBFluteRuntime.JavaLike.Lang;
using DBFluteRuntime.JavaLike.Math;
using System;

namespace DBFluteRuntime.JavaLike.Sql
{
    /// <summary>
    /// [Java]Statement
    /// </summary>
    public interface Statement
    {
        void close();
        void setQueryTimeout(int seconds);

        void setFetchSize(int size);

        void setMaxRows(int max);

        ResultSet executeQuery();

        int executeUpdate();

        int[] executeBatch();

        void addBatch();

        int getUpdateCount();

        void setBigDecimal(int parameterIndex, BigDecimal x);

        void setBinaryStream(int parameterIndex, InputStream x, int length);

        void setObject(int parameterIndex, object x);

        void setBoolean(int parameterIndex, boolean x);

        void setByte(int parameterIndex, byte x);

        void setString(int parameterIndex, string x);

        void setInt(int parameterIndex, int x);

        void setDouble(int parameterIndex, double x);

        void setFloat(int parameterIndex, float x);

        void setLong(int parameterIndex, long x);

        void setShort(int parameterIndex, short x);

        void setDate(int parameterIndex, DateTime x);

        void setTimestamp(int parameterIndex, DateTime x);

        void setTime(int parameterIndex, DateTime x);

        void setBlob(int parameterIndex, Blob x);

        void setBytes(int parameterIndex, byte[] x);

        void setNull(int parameterIndex, int sqlType, string typeName);

        void setCharacterStream(int parameterIndex, Reader reader, int length);
    }
}
