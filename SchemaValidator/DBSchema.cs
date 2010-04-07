using System.Collections.Generic;

namespace SchemaValidator
{
    public class DBSchema
    {

        // private fields
        private List<Table> _tableList; 
       

        // constructors
        public DBSchema()
        {
            _tableList = new List<Table>(); 
        }


        // properties
        public int TableCount
        {
            get {
                return _tableList.Count; 
            }
        }


        public Table RequireTable(string tableName)
        {
            Table table = _tableList.Find(x => x.Name == tableName);
            if (table == null)
            {
                Table newTable = new Table(tableName);
                _tableList.Add(newTable);
                table = newTable;
            }
            return table;
        }

        
    }
}
