using System.Collections.Generic;
using System;
using SchemaValidator.Extensions;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;
using System.Collections.ObjectModel;

namespace SchemaValidator
{
    public class SchemaSpecification
    {

        private readonly List<Table> _tableList;

        public ReadOnlyCollection<Table> Tables { get { return _tableList.AsReadOnly(); } }

        public SchemaSpecification()
        {
            _tableList = new List<Table>();
        }

        protected void AddTable(Table table)
        {
            // guard clause: Duplicated table not allowed, It could overwrite an specification by mistake
            if (_tableList.Exists(x => table.Name.EqualsIgnoreCase(x.Name)))
                throw new ApplicationException(string.Format("Table {0} already in specification", table.Name));

            _tableList.Add(table);
        }

        protected Table AddTable(string tableName)
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
                Table otherTable = otherSpec.FindTableByName(eachTable.Name);
                if (otherTable == null)
                    result.AddMissing(eachTable);
                else
                {
                    CompareResult compareResult = eachTable.Compare(otherTable);
                    if (compareResult.HaveValues)
                    {
                        var conflict = new SpecificationConflict(new Pair<Table>(eachTable, otherTable), compareResult);
                        result.AddConflict(conflict);
                    }
                }
            }
            return result;
        }

        private Table FindTableByName(string tableName)
        {
            return _tableList.Find(x => x.Name.EqualsIgnoreCase(tableName));
        }
    }
}
