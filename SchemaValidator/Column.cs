namespace SchemaValidator
{
    public class Column
    {

        // private 
        private readonly Table _parentTable; 


        // constructor
        public Column(string name, Table parentTable)
        {
            Name = name;
            _parentTable = parentTable; 
        }


        // properties
        public string Name { get; private set; }
        public string ColumnType { get; private set; }


        // methods
        public Column WithColumn( string columnName )
        {
            return _parentTable.WithColumn(columnName);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Column)) return false;
            return Equals((Column) obj);
        }


        public bool Equals(Column other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name);
        }


        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }


        public Column OfType(string columnType)
        {
            ColumnType = columnType;
            return this;
        }
    }
}
