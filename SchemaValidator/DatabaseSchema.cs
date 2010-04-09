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
        private List<Table> _tableList;


        // constructors
        public DatabaseSchema(string connectionString)
        {
            _connectionString = connectionString;
        }


        // properties
        public int TableCount { get { return _tableList.Count; } }

        
        // methods
        public int LoadTables()
        {
            System.Data.DataSet _records;

            
            return 0;
        }

        public int LoadTableFields(Table table)
        {
            return 0;
        }

        private System.Data.DataSet LoadDBTables()
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
                        _cmd.CommandText = "";
                        _cmd.Connection = _conn;

                        using (_adapter = new System.Data.SqlClient.SqlDataAdapter())
                        {
                            _adapter.SelectCommand = _cmd;
                            _adapter.Fill(_records, "");
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
