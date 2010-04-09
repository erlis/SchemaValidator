namespace SchemaValidator
{
    public class Column
    {

        // private 
        private readonly Table _parentTable;


        // constructors
        public Column(string name, Table parentTable)
        {
            _parentTable = parentTable;
            IsNullable = false;
            Name = name;
        }

        public Column(string name) : this(name, null) { }


        // properties
        public string Name { get; private set; }
        public string ColumnType { get; private set; }
        public int ColumnLength { get; private set; }
        public bool IsNullable { get; set; }


        // methods
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

        public Column WithColumn(string columnName)
        {
            return _parentTable.WithColumn(columnName);
        }

        // equals members
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
            return Equals(other.Name.ToLower(), Name.ToLower()) &&
                   Equals(other.ColumnType.ToLower(), ColumnType.ToLower()) &&
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
    }
}
