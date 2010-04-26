using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.DbProviders
{

    public class OracleProvider : IDbProvider
    {

        // private fields and properties
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            private set
            {
                if (value == null) throw new ArgumentException("Connection String must be not null");
                if (value == string.Empty) throw new ArgumentException("Connection String must be not empty");
                _connectionString = value;
            }
        }

        private string _owner;
        public string Owner
        {
            get { return _owner; }
            private set
            {
                if (value == null) throw new ArgumentException("Owner must be not null");
                if (value == string.Empty) throw new ArgumentException("Owner must be not empty");
                _owner = value;
            }
        }

        private readonly List<Table> _tableList;
        private OracleConnection _connection = null;
        private DataTable _providertables;


        // constructors
        public OracleProvider(string connectionstring, string owner)
        {
            ConnectionString = connectionstring;
            Owner = owner;
            _tableList = new List<Table>();
        }


        // properties
        public int TableCount { get { return _tableList.Count; } }


        // methods
        public DbSpecification LoadDbSpecification()
        {
            // load database info
            DataSet records = LoadDBInfo();

            // create schema specification
            return CreateDbSpecification(records);
        }

        private DbSpecification CreateDbSpecification(DataSet ds)
        {
            // fill Provider Tables Info
            _providertables = FillProviderTableInfo(ds);

            // add tables and their fields
            return AddTablesAndTheirFieldsToSpecification();
        }

        private DataTable FillProviderTableInfo(DataSet ds)
        {
            return ds != null && ds.Tables.Contains("dbtables") ? ds.Tables["dbtables"] : null;
        }

        private DbSpecification AddTablesAndTheirFieldsToSpecification()
        {
            List<Table> tables = new List<Table>();

            // query tables
            var DistintTableQuery = (from table in _providertables.AsEnumerable()
                                     select new { TableName = table.Field<string>("TableName") }).Distinct();

            // add tables and their fields
            foreach (var tn in DistintTableQuery)
            {
                // add table
                Table tb = new Table(tn.TableName);

                // add columns
                AddColumnsToTable(tb);
                tables.Add(tb);
            }

            return new DbSpecification(tables);
        }

        private void AddColumnsToTable(Table table)
        {
            Column cl;

            // query columns
            var FieldsQuery = (from column in _providertables.AsEnumerable()
                               where column.Field<string>("TableName") == table.Name
                               select new
                               {   ColumnName = column.Field<string>("ColumnName")
                                   , DataType = column.Field<string>("DataType")
                                   , Length = column.Field<string>("Length")
                                   , IsNullable = column.Field<string>("IsNullable")

                               }).Distinct();

            // add columns
            foreach (var fn in FieldsQuery)
            {
                cl = Column.CreateWithTable(fn.ColumnName, table);
                cl.OfType(fn.DataType, Convert.ToInt16(fn.Length));
                if (fn.IsNullable == "Y") cl.Nullable();
            }
        }

        private DataSet LoadDBInfo()
        {
            DataSet _records = new DataSet();

            try
            {
                // create connection
                CreateProviderConnection();
                // open connection
                OpenProviderConnection();
                // execute sql to get the tables
                _records = GetProviderInfoTables();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseProviderConnection();
            }

            return _records;
        }

        private void CloseProviderConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open) _connection.Close();
        }

        private DataSet GetProviderInfoTables()
        {
            OracleCommand _cmd;
            DataSet _records = new DataSet();

            using (_cmd = new OracleCommand())
            {
                _cmd.CommandText = "SELECT  " +
                                                    "  sc.table_name AS TableName,  " +
                                                    "  sc.column_name AS ColumnName, " +
                                                    "  sc.data_type AS DataType, " +
                                                    "  to_char(sc.data_length) AS Length, " +
                                                    "  to_char(sc.nullable) AS IsNullable " +
                                                    "FROM  " +
                                                    "  sys.all_tables so " +
                                                    "  INNER JOIN sys.all_tab_columns sc ON so.table_name = sc.table_name " +
                                                    "WHERE  " +
                                                    "  so.owner = '" + Owner + "'  " +
                                                    "ORDER BY " +
                                                    "  sc.table_name";


                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = _connection;

                _records = FillDataSetFromDataAdapter(_cmd);
            }

            return _records;
        }

        private static DataSet FillDataSetFromDataAdapter(OracleCommand _cmd)
        {
            OracleDataAdapter _adapter;
            DataSet _records = new DataSet();

            using (_adapter = new OracleDataAdapter())
            {
                _adapter.SelectCommand = _cmd;
                _adapter.Fill(_records, "dbtables");
            }
            return _records;
        }

        private void OpenProviderConnection()
        {
            _connection.Open();
        }

        private OracleConnection CreateProviderConnection()
        {
            return _connection = new OracleConnection(this._connectionString);
        }

    }
}
