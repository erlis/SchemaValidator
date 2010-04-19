using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchemaValidator.ValueObjects.SpecComparable;

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

        private readonly List<ISpecComparable> _missingList;
        public ReadOnlyCollection<ISpecComparable> MissingList
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
            _missingList = new List<ISpecComparable>();
        }

        /// methods
        public void AddConflict( Pair pair )
        {
            _conflictList.Add(pair);
        }

        public void AddMissing(ISpecComparable element)
        {
            _missingList.Add(element);
        }
    }
}