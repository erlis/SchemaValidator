using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            _connectionString = connectionString;
        }


        // properties
        public int TableCount { get { return _tableList.Count; } }

        
        // methods
        public SchemaSpecification LoadSchemaSpecification()
        {
            SchemaSpecification _SchSpec = new SchemaSpecification();
            System.Data.DataSet _records;

            // load database info
            _records = this.LoadDBInfo();

            // create schema specification
            _SchSpec = CreateSchemaSpecification(_records);

            return _SchSpec;
        }

        private SchemaSpecification CreateSchemaSpecification(System.Data.DataSet ds)
        {
            SchemaSpecification _schspec = new SchemaSpecification();
            System.Data.DataTable tables = ds.Tables["dbtables"];

            var DistintTableQuery = (from System.Data.DataRow dRow in tables.Rows
                                     select new { tablename = dRow["tablename"] }).Distinct();


            foreach (var r in DistintTableQuery)
            _schspec.RequireTable(r.tablename.ToString());

            return _schspec;
        }

        private int LoadTableFields(Table table)
        {
            return 0;
        }

        private System.Data.DataSet LoadDBInfo()
        {
            System.Data.DataSet _records = new System.Data.DataSet();
            System.Data.SqlClient.SqlConnection _conn = null;
            System.Data.SqlClient.SqlCommand _cmd;
            System.Data.SqlClient.SqlDataAdapter _adapter;

            try
            {
                // create connection
                using (_conn = new System.Data.SqlClient.SqlConnection(this._connectionString))
                {
                    // open connection
                    _conn.Open();

                    // execute sql to get the tables
                    using (_cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        //SELECT     
                        //                        tables.name AS tablename, 
                        //                        columns.name AS columnname, 
                        //                        types.name AS typename, 
                        //                        columns.is_nullable, 
                        //                        columns.max_length, 
                        //                        columns.precision, 
                        //                        columns.scale
                        //FROM         
                        //                        sys.tables AS tables INNER JOIN sys.columns AS columns ON tables.object_id = columns.object_id 
                        //                                                      INNER JOIN sys.types AS types ON columns.system_type_id = types.system_type_id
                        //ORDER BY 
                        //                        tablename, 
                        //                        columnname
                        _cmd.CommandText = "SELECT tables.name AS tablename, columns.name AS columnname, types.name AS typename, columns.is_nullable, columns.max_length, " + 
                                                                        "columns.precision, columns.scale FROM sys.tables AS tables INNER JOIN sys.columns AS columns ON tables.object_id = columns.object_id INNER JOIN " +
                                                                        "sys.types AS types ON columns.system_type_id = types.system_type_id ORDER BY tablename, columnname";
                        _cmd.CommandType = System.Data.CommandType.Text;
                        _cmd.Connection = _conn;

                        
                        using (_adapter = new System.Data.SqlClient.SqlDataAdapter())
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
                if (_conn.State == System.Data.ConnectionState.Open) _conn.Close();
            }

            return _records;
        }

    }
}
