namespace SchemaValidator
{
    public class Column
    {

        // private 
        private readonly Table _parentTable;


        // constructors
        public Column(string name, Table parentTable)
        {
            Name = name;
            _parentTable = parentTable;
        }

        public Column(string name) : this(name, null) { }


        // properties
        public string Name { get; private set; }
        public string ColumnType { get; private set; }


        // methods
        public Column WithColumn(string columnName)
        {
            return _parentTable.WithColumn(columnName);
        }


        public Column OfType(string columnType)
        {
            ColumnType = columnType;
            return this;
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
            return Equals(other.Name.ToLower(), Name.ToLower()) && 
                   Equals(other.ColumnType.ToLower(), ColumnType.ToLower());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.ToLower().GetHashCode() : 0)*397) ^ 
                        (ColumnType != null ? ColumnType.ToLower().GetHashCode() : 0);
            }
        }
    }
}
