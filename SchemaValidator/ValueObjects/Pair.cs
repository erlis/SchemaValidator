using System;
using SchemaValidator.ValueObjects.SpecComparable;
namespace SchemaValidator.ValueObjects {
	public class Pair {

		public ISpecComparable First { get; private set; }
		public ISpecComparable Second { get; private set; }


        public Pair(ISpecComparable first, ISpecComparable second)
        {
            // guard clause: first and second must be of the same type
            if (first.GetType() != second.GetType() ) throw new ArgumentException( "First and Second must be of the same type");

			First = first;
			Second = second; 
		}

	}
}
