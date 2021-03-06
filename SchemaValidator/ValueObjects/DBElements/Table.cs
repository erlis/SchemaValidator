﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchemaValidator.Extensions;
using SchemaValidator.ValueObjects.Conflict;

namespace SchemaValidator.ValueObjects.DBElements
{
    public class Table : IDBElement
    {

        private readonly List<Column> _columnList;

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

        public ReadOnlyCollection<Column> Columns { get { return _columnList.AsReadOnly(); } }

        public Table(string name)
        {
            Name = name;
            _columnList = new List<Column>();
        }

        public void AddColumn( Column column )
        {
            // guard clause: Duplicated column not allowed, It could overwrite an specification by mistake
            if (_columnList.Exists(x => column.Name.EqualsIgnoreCase(x.Name)))
                throw new ApplicationException(string.Format("Column {0} already in the specification of table {1}", column.Name, Name));

            _columnList.Add( column );
        }

        public CompareResult Compare(Table otherTable)
        {
            // guard clause: Different table names are not comparables
            if (!Name.EqualsIgnoreCase(otherTable.Name))
                throw new InvalidOperationException("Tables are not comparables. In order to compare two tables they must have the same name.");

            CompareResult result = new CompareResult();
            foreach (Column eachColumn in _columnList)
            {
                Column otherColumn = otherTable.FindColumnByName(eachColumn.Name);
                if (otherColumn == null)
                    result.AddMissing(eachColumn);
                else
                    if (!eachColumn.Equals(otherColumn))
                    {
                        var conflict = new TableConflict(new Pair<Column>(eachColumn, otherColumn));
                        result.AddConflict(conflict);
                    }
            }
            return result;
        }

        public override string ToString()
        {
            string result = string.Format("[{0}]\n", Name);
            _columnList.ForEach( x => result += "   " + x.ToString() + "\n" );
            return result; 
        }

        public Column WithColumn(string columnName)
        {
            return Column.CreateWithTable(columnName, this);
        }

        private Column FindColumnByName(string columnName)
        {
            return _columnList.Find(x => x.Name.EqualsIgnoreCase(columnName));
        }
    }
}
