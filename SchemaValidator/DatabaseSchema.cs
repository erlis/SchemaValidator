using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaValidator
{
    public enum DatabaseType
    {
        MSSQLServer=0,
        Oracle=1
    }

    public class DatabaseSchema
    {

        // private fields
        private string _connectionString;
        private DatabaseType _dbType { get; set; }


        // constructors
        public DatabaseSchema(DatabaseType DbType, string connectionString)
        {
            _dbType = DbType;
            _connectionString = connectionString;
        }

        public DatabaseSchema(string connectionString)
        {
            _dbType = DatabaseType.MSSQLServer;
            _connectionString = connectionString;
        }


        // properties


    }
}
