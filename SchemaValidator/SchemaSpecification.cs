using System.Collections.Generic;

namespace SchemaValidator
{
    public class SchemaSpecification
    {

        // private fields
        private List<Table> _tableList; 
       

        // constructors
        public SchemaSpecification()
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
        	Table table = _tableList.Find( x => x.Name == tableName );

        	if ( table == null ) {
				table = new Table( tableName );
				_tableList.Add( table );
			}
			
            return table;
        }

        
    }
}
