using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects.Conflict
{
    public class TableConflict : IConflict
    {
        private readonly Pair<Column> _pair;

        public IDBElement First { get { return _pair.First; } }
        public IDBElement Second { get { return _pair.Second; } }
        public CompareResult Detail { get; private set; }

        public TableConflict(Pair<Column> pair)
        {
            _pair = pair;
            Detail = null; 
        }

        public override string ToString()
        {
            return ToStringIndent("");
        }

        public string ToStringIndent(string indent)
        {
            string result = "";
            result += string.Format("{0}Expected: {1}\n", indent, First);
            result += string.Format("{0}But was:  {1}\n\n", indent, Second);
            return result;
        }


    }
}