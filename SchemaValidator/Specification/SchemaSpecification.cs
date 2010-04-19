using System.Collections.Generic;
using System;
using SchemaValidator.Extensions;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.Specification
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


        public CompareResult Compare(SchemaSpecification otherSpec)
        {
            CompareResult result = new CompareResult();
            foreach (var eachTable in _tableList)
            {
                Table table = eachTable;
                Table otherTable = otherSpec._tableList.Find(x => x.Name.EqualsIgnoreCase(table.Name));
                if (otherTable == null)
                    result.AddMissing(eachTable);
                else
                {
                    CompareResult compareResult = eachTable.Compare(otherTable);
                    if (compareResult.HaveValues)
                    {
                        var conflict = new Conflict(new Pair(eachTable, otherTable), compareResult);
                        result.AddConflict(conflict);
                    }
                }
            }
            return result;
        }
    }
}
