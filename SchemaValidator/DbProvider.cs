using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Linq;
using SchemaValidator.Specification;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator
{

    public class DbProvider : IDbProvider
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
        
        private readonly List<Table> _tableList;
        private SqlConnection _connection = null;
        private DataTable _providertables;


        // constructors
        public DbProvider(string connectionstring)
        {
            ConnectionString = connectionstring;
            _tableList = new List<Table>();
        }


        // properties
        public int TableCount { get { return _tableList.Count; } }

        
        // methods
        public SchemaSpecification LoadSchemaSpecification()
        {
            SchemaSpecification _SchSpec = null;
            DataSet _records;

            // load database info
            _records = this.LoadDBInfo();

            // create schema specification
            _SchSpec = CreateSchemaSpecification(_records);

            return _SchSpec;
        }

        private SchemaSpecification CreateSchemaSpecification(DataSet ds)
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

        private SchemaSpecification AddTablesAndTheirFieldsToSpecification()
        {
            SchemaSpecification _schspec = new SchemaSpecification();
            Table tb;
            Column cl;

            // query tables
            var DistintTableQuery = (from table in _providertables.AsEnumerable()
                                     select new { TableName = table.Field<string>("TableName") }).Distinct();

            // add tables and their fields
            foreach (var tn in DistintTableQuery)
            {
                // add table
                tb = _schspec.AddTable(tn.TableName);
                // add columns
                AddColumnsToTable(tb);
            }

            return _schspec; ;
        }

        private void AddColumnsToTable(Table table)
        {
            Column cl;

            // query columns
            var FieldsQuery = (from column in _providertables.AsEnumerable()
                               where column.Field<string>("TableName") == table.Name
                               select new
                               {  ColumnName = column.Field<string>("ColumnName")
                                   , DataType = column.Field<string>("DataType")
                                   , Length = column.Field<Int16>("Length")
                                   , IsNullable = column.Field<int>("IsNullable")
                               }).Distinct();

            // add columns
            foreach (var fn in FieldsQuery)
            {
                cl = Column.CreateWithTable(fn.ColumnName, table);
                cl.OfType(fn.DataType, fn.Length); 
                if (Convert.ToBoolean(fn.IsNullable)) cl.Nullable();
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
                throw(ex);
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
            SqlCommand _cmd;
            DataSet _records = new DataSet() ;

            using (_cmd = new SqlCommand())
            {
                _cmd.CommandText = "SELECT " +
                                                    "    so.name AS TableName, " +
                                                    "    sc.name AS ColumnName, " +
                                                    "    st.name AS DataType, " +
                                                    "    sc.Length AS Length, " +
                                                    "    sc.isnullable AS IsNullable " +
                                                    "FROM    " +
                                                    "    SysObjects so " +
                                                    "       INNER JOIN SysColumns sc " +
                                                    "           ON so.id = sc.id " +
                                                    "       INNER JOIN SysTypes st " +
                                                    "           ON st.xtype = sc.xtype AND st.xusertype = sc.xusertype " +
                                                    "WHERE  " +
                                                    "    so.Type = 'U' " +
                                                    "ORDER BY  " +
                                                    "    so.Name";

                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = _connection;

                _records = FillDataSetFromDataAdapter(_cmd);
            }

            return _records;
        }

        private static DataSet FillDataSetFromDataAdapter(SqlCommand _cmd)
        {
            SqlDataAdapter _adapter;
            DataSet _records = new DataSet();

            using (_adapter = new SqlDataAdapter())
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

        private SqlConnection CreateProviderConnection()
        {
            return _connection = new SqlConnection(this._connectionString);
        }

    }
}
