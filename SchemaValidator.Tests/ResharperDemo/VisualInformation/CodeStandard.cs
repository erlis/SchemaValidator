using System;

namespace VisualInformation {
	public class CodeStandard {

		public CodeStandard() {
			invalidMethodName();
		}


		// invalid code standard for class names
		private class innerClass {
			
		}

		private int _index; 
		
		private static void invalidMethodName() {
			Console.Out.WriteLine( "This is an invalid Standard Method Name" );
		}

	}
}