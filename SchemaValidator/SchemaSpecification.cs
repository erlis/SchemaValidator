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
        public Table RequireTable(string tableName)
        {
            // guard clause: Duplicated table not allowed, It could overwrite an specification by mistake
            if (_tableList.Exists(x => tableName.EqualsIgnoreCase(x.Name)))
                throw new ApplicationException(string.Format("Table {0} already in specification", tableName));

            Table table = new Table(tableName);
            _tableList.Add(table);
            return table;
        }


    }
}
