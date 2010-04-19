using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects
{
    public class CompareResult
    {
        /// properties
        private readonly List<Conflict> _conflictList;
        public ReadOnlyCollection<Conflict> ConflictList
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
            _conflictList = new List<Conflict>();
            _missingList = new List<IDBElement>();
        }

        /// methods
        public void AddConflict(Conflict conflict)
        {
            _conflictList.Add(conflict);
        }

        public void AddMissing(IDBElement element)
        {
            _missingList.Add(element);
        }

        public override string ToString()
        {
            if (!HaveValues) return "";
            string result = "";

            if ( _missingList.Count > 0 )
            {
                result = string.Format("Missing {0}(s)\n", _missingList[0].GetType().Name) +
                         "----------------\n";
                _missingList.ForEach( x => result += x.ToString() + "\n");

            }
            return result; 
        }
    }
}