using System;
using System.Collections.ObjectModel;
using SchemaValidator.Extensions;

namespace SchemaValidator.ValueObjects.DBElements
{
    public class Column : IDBElement
    {
        /// private fields
        internal Table ParentTable { get; set; }

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
        //todo: refactoring this, there is no way to create a column, this constructor must be private.
        public Column(string name)
        {
            ParentTable = null; 
            IsNullable = false;
            Name = name;
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
			return ParentTable; 
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
            return ParentTable.WithColumn(columnName);
        }
    }
}
