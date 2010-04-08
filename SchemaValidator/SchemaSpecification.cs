using System.Collections.Generic;
using System;

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
        public int TableCount { get { return _tableList.Count; } }


        // methods
        public Table RequireTable(string tableName)
        {
            // guard clause: Duplicated table not allowed, It could overwrite an specification by mistake
            if (_tableList.Exists(x => x.Name == tableName))
                throw new ApplicationException(string.Format("Table {0} already in specification", tableName));

            Table table = new Table(tableName);
            _tableList.Add(table);
            return table;
        }


    }
}
