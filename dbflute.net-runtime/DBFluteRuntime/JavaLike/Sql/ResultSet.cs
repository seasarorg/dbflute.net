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

        /// <summary>
        /// 先頭レコードを参照
        /// </summary>
        public void beforeFirst()
        {
            _currentRowNo = 0;
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
