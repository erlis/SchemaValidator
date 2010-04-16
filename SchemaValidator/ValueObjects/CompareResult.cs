using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchemaValidator.ValueObjects
{
    public class CompareResult
    {
        /// properties
        private List<Column> _conflictColumns;
        public ReadOnlyCollection<Column> ConflictColumns
        {
            get
            {
                return _conflictColumns.AsReadOnly();
            }
        }

        public bool HaveValues
        {
            get
            {
                if ( _conflictColumns.Count > 0) return true; 
                if (_missingColumns.Count > 0) return true;
                return false;
            }
        }

        private List<Column> _missingColumns;
        public ReadOnlyCollection<Column> MissingColumns
        {
            get
            {
                return _missingColumns.AsReadOnly();
            }
        }

        /// constructor
        public CompareResult()
        {
            _conflictColumns = new List<Column>();
            _missingColumns = new List<Column>();
        }


        public void AddConflictColumn(Column column)
        {
            _conflictColumns.Add(column);
        }

        /// methods
        public void AddMissingColumn(Column column)
        {
            _missingColumns.Add(column);
        }
    }
}