using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchemaValidator.ValueObjects
{
    public class CompareResult<T>
    {
        /// properties
        private readonly List<T> _conflictList;
        public ReadOnlyCollection<T> Conflict
        {
            get
            {
                return _conflictList.AsReadOnly();
            }
        }

        public bool HaveValues
        {
            get
            {
                if (_conflictList.Count > 0) return true;
                if (_missingList.Count > 0) return true;
                return false;
            }
        }

        private readonly List<T> _missingList;
        public ReadOnlyCollection<T> Missing
        {
            get
            {
                return _missingList.AsReadOnly();
            }
        }

        /// constructor
        public CompareResult()
        {
            _conflictList = new List<T>();
            _missingList = new List<T>();
        }

        /// methods
        public void AddConflict(T column)
        {
            _conflictList.Add(column);
        }

        public void AddMissing(T column)
        {
            _missingList.Add(column);
        }
    }
}