using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects.Conflict
{
    public class SpecificationConflict : IConflict
    {
        private readonly Pair<Table> _pair;

        public IDBElement First { get { return _pair.First; } }
        public IDBElement Second { get { return _pair.Second; } }
        public CompareResult Detail { get; private set; }

        public SpecificationConflict(Pair<Table> pair, CompareResult detail)
        {
            _pair = pair;
            Detail = detail;
        }

        public SpecificationConflict(Pair<Table> pair) : this(pair, null) { }

        public override string ToString()
        {
           return ToStringIndent(""); 
        }

        public string ToStringIndent(string indent)
        {
            return string.Format("{0}[{1}]\n", indent, First.Name) +
                   Detail.ToStringIndent(indent + "   ");
        }
        
    }
}