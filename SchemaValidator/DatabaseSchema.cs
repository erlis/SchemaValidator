using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Linq;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator
{

    public class DatabaseSchema : IDatabaseSchema
    {

        // private fields
        private string _connectionString;
        private List<Table> _tableList = new List<Table>();


        // constructors
        public DatabaseSchema(string connectionString)
        {
            if (connectionString == null) throw new ArgumentException("Connection String must be not null");
            if (connectionString == string.Empty) throw new ArgumentException("Connection String must be not empty");
            _connectionString = connectionString;
        }


        // properties
        public int TableCount { get { return _tableList.Count; } }

        
        // methods
        public SchemaSpecification LoadSchemaSpecification()
        {
            SchemaSpecification _SchSpec = new SchemaSpecification();
            DataSet _records;

            // load database info
            _records = this.LoadDBInfo();

            // create schema specification
            _SchSpec = CreateSchemaSpecification(_records);

            return _SchSpec;
        }

        private SchemaSpecification CreateSchemaSpecification(DataSet ds)
        {
            SchemaSpecification _schspec = new SchemaSpecification();
            DataTable tables = ds.Tables["dbtables"];
            Table t;
            Column cl;

            // query tables
            var DistintTableQuery = (from table in tables.AsEnumerable()
                                     select new { TableName = table.Field<string>("TableName") }).Distinct();
            
            // add tales and their fields
            foreach (var tn in DistintTableQuery)
            {
                // add table
                t = _schspec.AddTable(tn.TableName);

                // query columns
                var FieldsQuery = (from column in tables.AsEnumerable()
                                               where column.Field<string>("TableName") == tn.TableName
                                               select new {   
                                                                    ColumnName = column.Field<string>("ColumnName")
                                                                    , DataType = column.Field<string>("DataType")
                                                                    , Length = column.Field<Int16>("Length")
                                                                    , IsNullable = column.Field<int>("IsNullable")
                                               }).Distinct();

                // add columns
                foreach (var fn in FieldsQuery)
                {
                    cl = new Column(fn.ColumnName, t);
                    cl.OfType(fn.DataType, fn.Length);
                    if (Convert.ToBoolean(fn.IsNullable)) cl.Nullable();
                }
            }

            return _schspec;
        }

        private DataSet LoadDBInfo()
        {
            DataSet _records = new DataSet();
            SqlConnection _conn = null;
            SqlCommand _cmd;
            SqlDataAdapter _adapter;

            try
            {
                // create connection
                using (_conn = new SqlConnection(this._connectionString))
                {
                    // open connection
                    _conn.Open();

                    // execute sql to get the tables
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
                                                            "           on so.id = sc.id " +
                                                            "       INNER JOIN SysTypes st " +
                                                            "           on st.xtype = sc.xtype " +
                                                            "WHERE  " +
                                                            "    so.Type = 'U' " +
                                                            "ORDER BY  " +
                                                            "    so.Name";

                        _cmd.CommandType = CommandType.Text;
                        _cmd.Connection = _conn;

                        
                        using (_adapter = new SqlDataAdapter())
                        {
                            _adapter.SelectCommand = _cmd;
                            _adapter.Fill(_records, "dbtables");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open) _conn.Close();
            }

            return _records;
        }

    }
}
