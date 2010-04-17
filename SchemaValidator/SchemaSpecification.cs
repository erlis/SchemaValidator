using System.Collections.Generic;
using System;
using SchemaValidator.Extensions;
using SchemaValidator.ValueObjects;

namespace SchemaValidator
{
    public class SchemaSpecification
    {

        /// private fields
        private readonly List<Table> _tableList;

        /// properties
        public int TableCount { get { return _tableList.Count; } }


        /// constructors
        public SchemaSpecification()
        {
            _tableList = new List<Table>();
        }


        /// methods
        public Table AddTable(string tableName)
        {
            // guard clause: Duplicated table not allowed, It could overwrite an specification by mistake
            if (_tableList.Exists(x => tableName.EqualsIgnoreCase(x.Name)))
                throw new ApplicationException(string.Format("Table {0} already in specification", tableName));

            Table table = new Table(tableName);
            _tableList.Add(table);
            return table;
        }


    	public CompareResult<Table> Compare( SchemaSpecification otherSpec ) {
    		CompareResult<Table> result = new CompareResult<Table>();
    		foreach ( var eachTable in _tableList ) {
    			Table otherTable = otherSpec._tableList.Find( x => x.Name.EqualsIgnoreCase( eachTable.Name ) );
				if ( otherTable == null ) result.AddMissingColumn( eachTable );
    		}
    		return result; 
    	}
    }
}
