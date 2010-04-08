﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SchemaValidator
{
    public class Table
    {

        // privates
        private List<Column> _columnList; 


        // constructor 
        public Table(string name)
        {
            Name = name;
            _columnList = new List<Column>(); 
        }


        // properties
        public string Name { get; private set; }
        public int ColumnCount { get { return _columnList.Count; } }


        // methods
        public Column WithColumn(string columnName)
        {
            // guard clause: Duplicated column not allowed, It could overwrite an specification by mistake
            if (_columnList.Exists(x => x.Name == columnName))
                throw new ApplicationException( string.Format( "Column {0} already in the specification of table {0}", columnName, this.Name ) ); 

            Column column = new Column(columnName);
            _columnList.Add(column); 
            return column; 
        }

    }
}
