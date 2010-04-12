using System;
using System.Collections.Generic;

namespace SchemaValidator
{
    public class Table
    {

        // privates
        private readonly List<Column> _columnList; 


        // constructor 
        public Table(string name)
        {
            Name = name;
            _columnList = new List<Column>(); 
        }


        // properties
        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if ( value == null ) throw new ArgumentException("Name must be not null");
                _name = value;
            }
        }

        public int ColumnCount { get { return _columnList.Count; } }


        // methods
        public Column WithColumn(string columnName)
        {
            // guard clause: Duplicated column not allowed, It could overwrite an specification by mistake
            if (_columnList.Exists(x => x.Name.ToLower() == columnName.ToLower()))
                throw new ApplicationException( string.Format( "Column {0} already in the specification of table {1}", columnName, Name ) ); 

            Column column = new Column(columnName, this);
            _columnList.Add(column); 
            return column; 
        }

        // equals members
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Table)) return false;
            return Equals((Table) obj);
        }

        public bool Equals(Table other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && ColumnsEquals(other._columnList, _columnList);
        }

        private bool ColumnsEquals(IEnumerable<Column> columns1, IEnumerable<Column> columns2)
        {
            if (columns1 == null  ^  columns2 == null ) return false;

            return true; 
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_columnList != null ? _columnList.GetHashCode() : 0)*397) ^ 
                        (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}
