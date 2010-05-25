using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects.Conflict
{
    public class CompareResult
    {
        /// properties
        private readonly List<IConflict> _conflictList;
        public ReadOnlyCollection<IConflict> ConflictList
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
            _conflictList = new List<IConflict>();
            _missingList = new List<IDBElement>();
        }

        /// methods
        public void AddConflict(IConflict conflict)
        {
            _conflictList.Add(conflict);
        }

        public void AddMissing(IDBElement element)
        {
            _missingList.Add(element);
        }

        public override string ToString()
        {
            return ToStringIndent("");
        }

        public string ToStringIndent(string indent)
        {
            if (!HaveValues) return "";
            string result = "";

            if (_missingList.Count > 0)
            {
                result += string.Format("{0}Missing {1}(s)\n{0}----------------\n", indent, _missingList[0].GetType().Name);
                _missingList.ForEach(x => result += string.Format("{0}{1}\n", indent, x.ToString()));

            }

            if (_conflictList.Count > 0)
            {
                result += string.Format("{0}Conflict {1}(s)\n{0}----------------\n", indent, _conflictList[0].First.GetType().Name);
                _conflictList.ForEach(x => result += x.ToStringIndent(indent));
            }

            return result;
        }
    }
}