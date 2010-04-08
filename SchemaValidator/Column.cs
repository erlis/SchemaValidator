using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaValidator
{
    public class Column
    {
        // properties
        public string Name { get; private set; }


        // constructor
        public Column(string name)
        {
            Name = name; 
        }
    }
}
