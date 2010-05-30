using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaValidator.Tests.ResharperDemo.VisualInformation {

	public class DeadCode {
		const double CONST = 1;


		public DeadCode() {
		}
        
		private void UnusedMethod() {
		}


		public void PublicMethod() {
			int unusedVariable;
			UnusedReturnValue();
			Console.Out.WriteLine( RedundantElse() );
		}


		private bool UnusedReturnValue() {
			return true;
		}


		private string RedundantElse() {
			long value = DateTime.Now.Ticks;
			if ( value % 2 == 0 ) {
				return "true";
			}
			else
				return "false";
		}


		public string UnreachedCode() {
			if (  CONST < 5 )
				return "less than five";
			else {
				Console.Out.WriteLine( "This code is never reached." );
				return "Greater than five";
			}
		}


		public string UnreachedCodeByException() {
			try {
				int i = 2;
				Console.Out.WriteLine( i );
				throw new Exception( "Throwing in the middle of the code" );
				Console.Out.WriteLine( "This code is never reached." );
				i = 4;
				Console.Out.WriteLine( i );
			}
			catch ( Exception ) {
				throw;
			}	
		}
	}

}