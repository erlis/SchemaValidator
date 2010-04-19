using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects
{
    public class CompareResult
    {
        /// properties
        private readonly List<Pair> _conflictList;
        public ReadOnlyCollection<Pair> ConflictList
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

        private readonly List<IDBElement> _missingList;
        public ReadOnlyCollection<IDBElement> MissingList
        {
            get
            {
                return _missingList.AsReadOnly();
            }
        }

        /// constructor
        public CompareResult()
        {
            _conflictList = new List<Pair>();
            _missingList = new List<IDBElement>();
        }

        /// methods
        public void AddConflict( Pair pair )
        {
            _conflictList.Add(pair);
        }

        public void AddMissing(IDBElement element)
        {
            _missingList.Add(element);
        }
    }
}