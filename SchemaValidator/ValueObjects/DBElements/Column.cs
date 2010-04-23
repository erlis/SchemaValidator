using System;
using System.Collections.ObjectModel;
using SchemaValidator.Extensions;

namespace SchemaValidator.ValueObjects.DBElements
{
    public class Column : IDBElement
    {
        /// private fields
        private Table _parentTable;

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
        public string ColumnType { get; private set; }
        public int ColumnLength { get; private set; }
        public bool IsNullable { get; set; }

        /// constructors
        private Column(string name)
        {
            _parentTable = null;
            IsNullable = false;
            Name = name;
        }

        public static Column Create( string columnName )
        {
            return new Column(columnName);
        }

        public static Column CreateWithTable(string columnName, Table table)
        {
            Column result = Create(columnName); 
            if ( table != null )
            {
                result._parentTable = table;
                table.AddColumn( result );
            }
            return result; 
        }


        /// methods
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Column)) return false;
            return Equals((Column)obj);
        }

        public bool Equals(Column other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name.EqualsIgnoreCase(other.Name) &&
                   ColumnType.EqualsIgnoreCase(other.ColumnType) &&
                   Equals(other.ColumnLength, ColumnLength) &&
                   Equals(other.IsNullable, IsNullable);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.ToLower().GetHashCode() : 0) * 397) ^
                       ((ColumnType != null ? ColumnType.ToLower().GetHashCode() : 0) * 397) ^
                       (ColumnLength * 397) ^
                       ((IsNullable ? 1 : 0) * 397);
            }
        }

		public Table GetTable() {
			return _parentTable; 
		}

        public Column Nullable()
        {
            IsNullable = true;
            return this;
        }

        public Column OfType(string columnType, int length)
        {
            ColumnType = columnType;
            ColumnLength = length;
            return this;
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}({2}){3}", Name, ColumnType, ColumnLength, IsNullable ? " NULLABLE" : "");
        }

        public Column WithColumn(string columnName)
        {
            return _parentTable.WithColumn(columnName);
        }
    }
}
