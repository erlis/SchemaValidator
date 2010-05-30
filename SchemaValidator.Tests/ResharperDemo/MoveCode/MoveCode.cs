using System;

namespace SchemaValidator.Tests.ResharperDemo.MoveCode {
	public class MoveCode {

		public MoveCode() {
			int initial = 5;

			if ( 3 > initial ) {
				initial = Add( initial, 4 );
			}
			Console.Out.WriteLine( "Value: " + initial );
		}

		private int Add( int n1, int n2 ) {
			return n1 + n2; 
		}

	}
}