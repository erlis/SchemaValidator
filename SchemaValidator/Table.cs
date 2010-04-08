using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SchemaValidator
{
    public class Table
    {

        // properties
        public string Name { get; private set; }


        // constructor 
        public Table(string name)
        {
            Name = name;
        }


        // methods
        public Column WithColumn(string columnName)
        {
            return new Column(columnName); 
        }

    }
}
