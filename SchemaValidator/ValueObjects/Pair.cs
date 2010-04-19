using SchemaValidator.ValueObjects.SpecComparable;
namespace SchemaValidator.ValueObjects {
	public class Pair {

		public ISpecComparable First { get; private set; }
		public ISpecComparable Second { get; private set; }


        public Pair(ISpecComparable first, ISpecComparable second)
        {
			First = first;
			Second = second; 
		}

	}
}
