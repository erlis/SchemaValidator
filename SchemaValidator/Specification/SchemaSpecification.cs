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
        protected void AddTable(Table table)
        {
            // guard clause: Duplicated table not allowed, It could overwrite an specification by mistake
            if (_tableList.Exists(x => table.Name.EqualsIgnoreCase(x.Name)))
                throw new ApplicationException(string.Format("Table {0} already in specification", table.Name));

            _tableList.Add( table );
        }

        public virtual Table AddTable(string tableName)
        {
            Table table = new Table(tableName);
            AddTable(table);
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
