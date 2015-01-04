using System.Data;

namespace DBFlute.JavaLike.Sql
{
    /// <summary>
    /// [Java]ResultSetMetaData
    /// </summary>
    public class ResultSetMetaData
    {
        private readonly DataTable _metaData;

        public ResultSetMetaData(DataTable metaData)
        {
            _metaData = metaData;
        }

        public int getColumnCount()
        {
            // #pending ADO.NETのメタデータDataTableの中身を確認後に実装
            return 0;
        }

        public string getColumnLabel(int columnIndex)
        {
            // #pending ADO.NETのメタデータDataTableの中身を確認後に実装
            return string.Empty;
        }

        // #pending 戻り値の方はjava.sql.Typesの中から
        public int getColumnType(int columnIndex)
        {
            // #pending ADO.NETのメタデータDataTableの中身を確認後に実装
            return 0;
        }
    }
}
