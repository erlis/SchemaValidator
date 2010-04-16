using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchemaValidator.ValueObjects
{
    public class CompareResult<T>
    {
        /// properties
        private List<T> _conflictColumns;
        public ReadOnlyCollection<T> ConflictColumns
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
                if (_conflictColumns.Count > 0) return true;
                if (_missingColumns.Count > 0) return true;
                return false;
            }
        }

        private List<T> _missingColumns;
        public ReadOnlyCollection<T> MissingColumns
        {
            get
            {
                return _missingColumns.AsReadOnly();
            }
        }

        /// constructor
        public CompareResult()
        {
            _conflictColumns = new List<T>();
            _missingColumns = new List<T>();
        }

        /// methods
        public void AddConflictColumn(T column)
        {
            _conflictColumns.Add(column);
        }

        public void AddMissingColumn(T column)
        {
            _missingColumns.Add(column);
        }
    }
}