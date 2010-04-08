using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    class SchemaSpecificationTests
    {
        private SchemaSpecification _schemaSpec; 

        [SetUp]
        public void SetUp()
        {
            _schemaSpec = new SchemaSpecification();
        }


        [Test]
        public void RequireTable_should_return_clase_Table()
        {
            // Act
            Table result = _schemaSpec.RequireTable("TableName");

            // Assert
            Assert.That(result.Name, Is.EqualTo("TableName"));
        }


        [Test]
        public void RequireTable_should_remember_previous_values()
        {
            // Act
            _schemaSpec.RequireTable("Table1");
            _schemaSpec.RequireTable("Table2"); 

            // Assert
            Assert.That(_schemaSpec.TableCount, Is.EqualTo(2)); 
        }


        [Test]
        public void RequireTable_should_avoid_duplicated_tablename()
        {
            // Act 
            _schemaSpec.RequireTable("Table1");
            _schemaSpec.RequireTable("Table1"); 

            // Assert
            Assert.That(_schemaSpec.TableCount, Is.EqualTo(1)); 
        }


		[Test]
		public void RequireTable_should_return_existing_table_when_duplicated_tablename() {
			// Arrange
			Table expected = _schemaSpec.RequireTable( "Table1" );
			_schemaSpec.RequireTable( "Table2" );

			// Act
			Table actual = _schemaSpec.RequireTable( "Table1" );

			// Assert
			Assert.That( actual, Is.SameAs( expected ) );
		}
    }
}
