using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SchemaValidator.Tests.ResharperDemo.VisualInformation {
	public class ResharperTeachesYou {

		public void OuterTrapVariable() {
			IEnumerable<char> query = "Not what you might expect";
			query = query.Where( c => c != 'a' );
			query = query.Where( c => c != 'e' );
			query = query.Where( c => c != 'i' );
			query = query.Where( c => c != 'o' );
			query = query.Where( c => c != 'u' );

			Console.Out.WriteLine( "All vowels are stripped, as you'd expect." );
			Console.Out.WriteLine( query.ToArray() );
			Console.Out.WriteLine( "" );

			query = "Not what you might expect";
			foreach ( char vowel in "aeiou" ) {
				query = query.Where( c => c != vowel );
			}
			Console.Out.WriteLine( "Notice that only the 'u' is stripped!" );
			Console.Out.WriteLine( query.ToArray() );
		}


		private List<int> GetList() {
			List<int> list = new List<int>();
			list.Add( 1 );
			list.Add( 2 );
			list.Add( 3 );
			list.Add( 4 );
			list.Add( 5 );
			list.Add( 6 );
			list.Add( 7 );
			return list;
		}


		public void MethodGroup() {
			List<int> list = GetList();

			List<int> even = list.FindAll( x => x%2 == 0 );
			List<int> odds = list.FindAll( x => x%2 != 0 );

			list.RemoveAll( x => even.Contains( x ) );

		}

	}




	/***********************************************************************************************/

	[TestFixture]
	public class ResharperTeachYouTests {

		[Test]
		public void OuterTrapVariableTest() {
			var example = new ResharperTeachesYou();
			example.OuterTrapVariable();
		}
	}

}