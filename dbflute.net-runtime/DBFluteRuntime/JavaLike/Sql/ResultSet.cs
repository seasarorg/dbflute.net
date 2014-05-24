using DBFluteRuntime.JavaLike.Lang;
using DBFluteRuntime.JavaLike.Math;
using System;
using System.Collections.Generic;
using System.Data;

namespace DBFluteRuntime.JavaLike.Sql
{
    // #pending 
    /// <summary>
    /// [Java]ResultSet
    /// </summary>
    public class ResultSet
    {
        /// <summary>
        /// C#におけるResultSet
        /// </summary>
        private readonly IDataReader _reader;

        /// <summary>
        /// 読み取り情報メタデータ
        /// </summary>
        private readonly ResultSetMetaData _metaData;

        /// <summary>
        /// 列名と列番号紐付けマップ
        /// </summary>
        private readonly IDictionary<string, int> _colNameIndexMap = new Dictionary<string, int>();

        /// <summary>
        /// 現在参照中のレコード番号
        /// </summary>
        private int _currentRowNo = 0;

        /// <summary>
        /// 読込済のレコードデータコレクション
        /// </summary>
        /// <remarks>
        /// .NETのIDataReaderは一つずつ先にしか読み進めることができないため、
        /// 前のレコードデータをキャッシュしている。
        /// </remarks>
        private IList<object[]> _cachedDatas = new List<object[]>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="reader"></param>
        public ResultSet(IDataReader reader)
        {
            _reader = reader;
            _metaData = new ResultSetMetaData(reader.GetSchemaTable());
        }

        /// <summary>
        /// テーブルメタデータの取得
        /// </summary>
        /// <returns></returns>
        public ResultSetMetaData getMetaData()
        {
            return _metaData;
        }

        /// <summary>
        /// 次レコードの参照
        /// </summary>
        /// <returns></returns>
        public Boolean next()
        {
            // 参照レコードがキャッシュ済の場合は行番号をインクリメントするのみ
            if (_cachedDatas.Count > _currentRowNo)
            {
                _currentRowNo++;
                return true;
            }

            // キャッシュ前であれば参照レコードのデータ全列分をキャッシュ
            bool hasNext = _reader.Read();
            if (hasNext)
            {
                _currentRowNo++;
                var rowData = new object[_reader.FieldCount];
                _reader.GetValues(rowData);
                _cachedDatas.Add(rowData);
            }
            return hasNext;
        }

        public boolean previous()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 先頭レコードを参照
        /// </summary>
        public void beforeFirst()
        {
            _currentRowNo = 0;
        }

        public void afterLast()
        {
            _currentRowNo = _cachedDatas.Count - 1;
            next();
        }

        /// <summary>
        /// 指定したレコードを参照
        /// </summary>
        /// <param name="rowNo"></param>
        public void absolute(int rowNo)
        {
            if (rowNo < 0)
            {
                beforeFirst();
            }
            else if(_cachedDatas.Count > rowNo)
            {
                _currentRowNo = rowNo;
            }
            else
            {
                // 読み取り前のレコードが指定された場合は、そのレコードまで読み進める
                for(int i = _cachedDatas.Count; i < rowNo; i++)
                {
                    if (!next())
                    {
                        break;
                    }
                }
            }
        }

        public boolean first()
        {
            throw new NotSupportedException();
        }

        public boolean isAfterLast()
        {
            throw new NotSupportedException();
        }

        public boolean isBeforeFirst()
        {
            throw new NotSupportedException();
        }

        public boolean isFirst()
        {
            throw new NotSupportedException();
        }

        public boolean isLast()
        {
            throw new NotSupportedException();
        }

        public boolean last()
        {
            throw new NotSupportedException();
        }

        public boolean rowDeleted()
        {
            throw new NotSupportedException();
        }

        public boolean rowInserted()
        {
            throw new NotSupportedException();
        }

        public boolean rowUpdated()
        {
            throw new NotSupportedException();
        }

        public boolean wasNull()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 現在レコード番号の取得
        /// </summary>
        /// <returns></returns>
        public int getRow()
        {
            return _currentRowNo;
        }

        /// <summary>
        /// ResultSetのクローズ
        /// </summary>
        public void close()
        {
            _reader.Close();   
        }

        public void cancelRowUpdates()
        {
            throw new NotSupportedException();
        }

        public void clearWarnings()
        {
            throw new NotSupportedException();
        }

        public void deleteRow()
        {
            throw new NotSupportedException();
        }

        public void insertRow()
        {
            throw new NotSupportedException();
        }

        public void updateNull(int columnIndex)
        {
            throw new NotSupportedException();
        }

        public void moveToCurrentRow()
        {
            _currentRowNo = _cachedDatas.Count - 1;
        }

        public void moveToInsertRow()
        {
            throw new NotSupportedException();
        }

        public void refreshRow()
        {
            throw new NotSupportedException();
        }

        public void updateRow()
        {
            throw new NotSupportedException();
        }

        public int getConcurrency()
        {
            throw new NotSupportedException();
        }

        public int getFetchDirection()
        {
            throw new NotSupportedException();
        }

        public int setFetchDirection()
        {
            throw new NotSupportedException();
        }

        public int getFetchSize()
        {
            throw new NotSupportedException();
        }

        public int setFetchSize()
        {
            throw new NotSupportedException();
        }

        public int getType()
        {
            throw new NotSupportedException();
        }



        public string getString(string columnName)
        {
            return getValue<string>(columnName);
        }

        public string getString(int columnIndex)
        {
            return getValue<string>(columnIndex);
        }

        public object getObject(string columnName)
        {
            return getValue<object>(columnName);
        }

        public object getObject(int columnIndex)
        {
            return getValue<object>(columnIndex);
        }

        public DateTime getDate(string columnName)
        {
            return getValue<DateTime>(columnName);
        }

        public DateTime getDate(int columnIndex)
        {
            return getValue<DateTime>(columnIndex);
        }

        public DateTime getTime(string columnName)
        {
            return getValue<DateTime>(columnName);
        }

        public DateTime getTime(int columnIndex)
        {
            return getValue<DateTime>(columnIndex);
        }

        public BigDecimal getBigDecimal(string columnName)
        {
            return null;
        }

        public BigDecimal getBigDecimal(int columnIndex)
        {
            return null;
        }

        // #pending get/setBinaryStream

        public DateTime getTimestamp(string columnName)
        {
            return getValue<DateTime>(columnName);
        }

        public DateTime getTimestamp(int columnIndex)
        {
            return getValue<DateTime>(columnIndex);
        }

        public byte[] getBytes(string columnName)
        {
            return getValue<byte[]>(columnName);
        }

        public byte[] getBytes(int columnIndex)
        {
            return getValue<byte[]>(columnIndex);
        }

        public byte[] getBlob(string columnName)
        {
            return getValue<byte[]>(columnName);
        }

        public byte[] getBlob(int columnIndex)
        {
            return getValue<byte[]>(columnIndex);
        }

        public Clob getClob(string columnName)
        {
            return getValue<Clob>(columnName);
        }

        public Clob getClob(int columnIndex)
        {
            return getValue<Clob>(columnIndex);
        }

        public Array getArray(string columnName)
        {
            return getValue<Array>(columnName);
        }

        public Array getArray(int columnIndex)
        {
            return getValue<Array>(columnIndex);
        }

        public void updateByte(int columnIndex, byte x)
        {
            throw new NotSupportedException();
        }

        public void updateDouble(int columnIndex, double x)
        {
            throw new NotSupportedException();
        }

        public void updateFloat(int columnIndex, float x)
        {
            throw new NotSupportedException();
        }

        public void updateInt(int columnIndex, int x)
        {
            throw new NotSupportedException();
        }

        public void updateLong(int columnIndex, long x)
        {
            throw new NotSupportedException();
        }

        public void updateShort(int columnIndex, short x)
        {
            throw new NotSupportedException();
        }

        public void updateBoolean(int columnIndex, boolean x)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 指定列名のデータ取得
        /// </summary>
        /// <typeparam name="VAL"></typeparam>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private VAL getValue<VAL>(string columnName)
        {
            return getValue<VAL>(_reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// 指定列番号のデータ取得
        /// </summary>
        /// <typeparam name="VAL"></typeparam>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private VAL getValue<VAL>(int columnIndex)
        {
            return (VAL)_cachedDatas[_currentRowNo][columnIndex];
        }
    }
}
