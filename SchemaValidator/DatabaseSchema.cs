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


        // constructors
        public DatabaseSchema(string connectionString)
        {
            _connectionString = connectionString;
        }


        // properties
        public int LoadTables()
        {
            return 0;
        }

        public int LoadTableFields(string tableName)
        {
            return 0;
        }

    }
}
