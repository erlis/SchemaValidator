using System;
using System.Collections.Generic;

namespace SchemaValidator
{
    public class Table
    {

        // privates
        private readonly List<Column> _columnList; 


        // constructor 
        public Table(string name)
        {
            Name = name;
            _columnList = new List<Column>(); 
        }


        // properties
        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if ( value == null ) throw new ArgumentException("Name must be not null");
                _name = value;
            }
        }

        public int ColumnCount { get { return _columnList.Count; } }


        // methods
        public Column WithColumn(string columnName)
        {
            // guard clause: Duplicated column not allowed, It could overwrite an specification by mistake
            if (_columnList.Exists(x => x.Name.ToLower() == columnName.ToLower()))
                throw new ApplicationException( string.Format( "Column {0} already in the specification of table {1}", columnName, Name ) ); 

            Column column = new Column(columnName, this);
            _columnList.Add(column); 
            return column; 
        }

        public List<string> Difference( Table table ) {
			// guard clause: Different names are not comparables
			if ( Name.ToLower() != table.Name.ToLower() )
				throw new InvalidOperationException( "Tables are not comparables. In order to compare two tables they must have the same table name." );
        	return new List<string>(); 
    	}
    }
}
