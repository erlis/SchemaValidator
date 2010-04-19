using System;
using SchemaValidator.ValueObjects.SpecComparable;

namespace SchemaValidator.ValueObjects
{
    public class Conflict
    {
        /// private fields
        private readonly Pair _pair;

        /// properties
        public object First { get { return _pair.First; } }
        public object Second { get { return _pair.Second; } }


        /// constructor
        public Conflict(Pair pair)
        {
            _pair = pair; 
        }
    }
}