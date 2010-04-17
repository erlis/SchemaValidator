namespace SchemaValidator.ValueObjects {
	public class Pair<F,S> {

		public F First { get; private set; }
		public S Second { get; private set; }
	

		public Pair( F first, S second) {
			First = first;
			Second = second; 
		}

	}
}
