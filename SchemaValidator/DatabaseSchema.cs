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
        private DatabaseType _dbType { get; private set; }
        private List<Table> _tableList; 


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


        // methods
        private void ConnectDB()
        {

        }

    }

    public class Database: IDatabase
    {
        // private fields
        private string _name;
        private string _dbCconnectionString;
        private List<Table> _tableList;


        // constructors
        public Database(string name, string dbCconnectionString) 
        { 
        }
        
        // methods
        public bool OpenDatabase() 
        {
            return true;
        }

        public bool CloseDataBase()
        {
            return true;
        }

        public int LoadTables()
        {
            return 0;
        }

        public int LoadTableFields(string tableName)
        {
            return 0;
        }

    }
    
    public interface IDatabase
    {
        // methods
        // create and open the connection
        bool OpenDatabase();
        // close and destroy the connection
        bool CloseDataBase();
        // load database tables
        init LoadTables();
        // load field by tablename
        int LoadTableFields(string tableName);
    }
}
