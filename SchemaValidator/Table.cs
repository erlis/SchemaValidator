using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; // testing ...

namespace SchemaValidator
{
    public class Table
    {

        public string Name { get; private set; }

        public Table(string name)
        {
            Name = name; 
        }


    }
}
