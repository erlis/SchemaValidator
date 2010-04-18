using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchemaValidator.ValueObjects
{
    public class CompareResult<T>
    {
        /// properties
        private readonly List<Pair<T>> _conflictList;
        public ReadOnlyCollection<Pair<T>> ConflictList
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
        public ReadOnlyCollection<T> MissingList
        {
            get
            {
                return _missingList.AsReadOnly();
            }
        }

        /// constructor
        public CompareResult()
        {
            _conflictList = new List<Pair<T>>();
            _missingList = new List<T>();
        }

        /// methods
        public void AddConflict( Pair<T> pair )
        {
            _conflictList.Add(pair);
        }

        public void AddMissing(T element)
        {
            _missingList.Add(element);
        }
    }
}