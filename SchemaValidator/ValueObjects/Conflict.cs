using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchemaValidator.ValueObjects
{
    public class Conflict
    {
        private List<Column> _missingColumns;
        public ReadOnlyCollection<Column> MissingColumns
        {
            get
            {
                return _missingColumns.AsReadOnly();
            }
        }

        public Conflict()
        {
            _missingColumns = new List<Column>();
        }

        public void AddMissingColumn(Column column)
        {
            _missingColumns.Add(column);
        }
    }
}