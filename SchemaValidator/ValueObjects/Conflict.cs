using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects
{
    public class Conflict
    {
        /// private fields
        private readonly Pair _pair;

        /// properties
        public IDBElement First { get { return _pair.First; } }
        public IDBElement Second { get { return _pair.Second; } }
        public CompareResult Detail { get; private set; }


        /// constructor
        public Conflict(Pair pair, CompareResult detail)
        {
            _pair = pair;
            Detail = detail;
        }
        public Conflict(Pair pair) : this(pair, null) { }
    }
}