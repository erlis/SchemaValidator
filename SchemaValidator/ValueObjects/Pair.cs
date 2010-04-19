using System;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects {
	public class Pair {

		public IDBElement First { get; private set; }
		public IDBElement Second { get; private set; }


        public Pair(IDBElement first, IDBElement second)
        {
            // guard clause: first and second must be of the same type
            if (first.GetType() != second.GetType() ) throw new ArgumentException( "First and Second must be of the same type");

			First = first;
			Second = second; 
		}

	}
}
