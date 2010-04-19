using System;
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

        /// methods
        public override string ToString()
        {
           return ToStringIndent(""); 
        }

        public string ToStringIndent(string indent)
        {
            string result = "";
            if ( Detail == null )
            {
                result += string.Format("{0}Expected: {1}\n", indent, First);
                result += string.Format("{0}But was:  {1}\n\n", indent, Second);
            }
            else
            {
                result += string.Format("{0}[{1}]\n", indent, First.Name);
                result += Detail.ToStringIndent(indent + "   ");
            }
            return result; 
        }
    }
}