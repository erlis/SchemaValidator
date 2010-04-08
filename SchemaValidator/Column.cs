using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaValidator
{
    public class Column
    {

        // private 
        private readonly Table _parentTable; 


        // constructor
        public Column(string name, Table parentTable)
        {
            Name = name;
            _parentTable = parentTable; 
        }


        // properties
        public string Name { get; private set; }


        // methods
        public Column WithColumn( string columnName )
        {
            return _parentTable.WithColumn(columnName);
        }
    }
}
