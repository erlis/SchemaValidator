using System;
using System.Collections.Generic;
using SchemaValidator.Extensions;
using SchemaValidator.ValueObjects;

namespace SchemaValidator
{
    public class Table
    {

        /// privates
        private readonly List<Column> _columnList;


        /// properties
        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (value == null) throw new ArgumentException("Name must be not null");
                _name = value;
            }
        }

        public int ColumnCount { get { return _columnList.Count; } }

        /// constructor 
        public Table(string name)
        {
            Name = name;
            _columnList = new List<Column>();
        }


        /// methods
        public CompareResult Compare(Table otherTable)
        {
            // guard clause: Different names are not comparables
            if (!Name.EqualsIgnoreCase(otherTable.Name))
                throw new InvalidOperationException("Tables are not comparables. In order to compare two tables they must have the same name.");

            CompareResult result = new CompareResult();
            foreach (Column eachColumn in _columnList)
            {
                Column otherColumn = otherTable.FindColumnByName(eachColumn.Name);
                if (otherColumn == null)
                    result.AddMissingColumn(eachColumn);
                else
                    if (!eachColumn.Equals(otherColumn))
                    {
                        result.AddConflictColumn(eachColumn);
                    }
            }

            return result;
        }

        public Column WithColumn(string columnName)
        {
            // guard clause: Duplicated column not allowed, It could overwrite an specification by mistake
            if (_columnList.Exists(x => columnName.EqualsIgnoreCase(x.Name)))
                throw new ApplicationException(string.Format("Column {0} already in the specification of table {1}", columnName, Name));

            Column column = new Column(columnName, this);
            _columnList.Add(column);
            return column;
        }

        private Column FindColumnByName(string columnName)
        {
            Column result = _columnList.Find(x => x.Name.EqualsIgnoreCase(columnName));
            return result;
        }
    }
}
