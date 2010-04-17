using System;
using NUnit.Framework;
using SchemaValidator.ValueObjects;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class SchemaSpecificationTests
    {
        private SchemaSpecification _schemaSpec; 

        [SetUp]
        public void SetUp()
        {
            _schemaSpec = new SchemaSpecification();
        }
		

        [Test]
        public void AddTable_should_return_clase_Table()
        {
            // Act
            Table result = _schemaSpec.AddTable("TableName");

            // Assert
            Assert.That(result.Name, Is.EqualTo("TableName"));
        }


        [Test]
        public void AddTable_should_remember_previous_values()
        {
            // Act
            _schemaSpec.AddTable("Table1");
            _schemaSpec.AddTable("Table2"); 

            // Assert
            Assert.That(_schemaSpec.TableCount, Is.EqualTo(2)); 
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void AddTable_should_throw_exception_when_duplicated()
        {
            // Act 
            _schemaSpec.AddTable("Table1");
            _schemaSpec.AddTable("Table1"); 
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void AddTable_should_be_case_insensitive()
        {
            // Act
            _schemaSpec.AddTable("TabLe1");
            _schemaSpec.AddTable("taBle1"); 
        }

		[Test]
		public void Compare_should_detect_different_tables() {
			// Arrange
			SchemaSpecification spec1 = new SchemaSpecification();
			spec1.AddTable( "t1" );
			Table expected = spec1.AddTable( "t2" ).WithColumn( "c1" ).GetTable();

			SchemaSpecification spec2 = new SchemaSpecification();
			spec2.AddTable( "t1" );
			spec2.AddTable( "t2" );

			// Act
			CompareResult<Table> result = spec1.Compare( spec2 );

			// Assert
			Assert.That( result.Conflict.Count, Is.EqualTo( 1 ) );
			Assert.That( result.Conflict[0], Is.SameAs( expected ) );
		}

		[Test]
		public void Compare_should_detect_missing_tables() {
			// Arrange
			SchemaSpecification spec1 = new SchemaSpecification();
			spec1.AddTable( "t1" );
			Table expected = spec1.AddTable( "t2" );

			SchemaSpecification spec2 = new SchemaSpecification();
			spec2.AddTable( "t1" );

			// Act
			CompareResult<Table> result = spec1.Compare( spec2 );

			// Assert
			Assert.That( result.Missing.Count, Is.EqualTo( 1 ) );
			Assert.That( result.Missing[0], Is.SameAs( expected ) );
		}

		[Test]
		public void Compare_should_ignore_extra_tables_in_the_other_specification() {
			// Arrange
			SchemaSpecification spec1 = new SchemaSpecification();
			spec1.AddTable( "t1" );
			
			SchemaSpecification spec2 = new SchemaSpecification();
			spec2.AddTable( "t1" );
			spec2.AddTable( "t2" );

			// Act
			CompareResult<Table> result = spec1.Compare( spec2 );

			// Assert
			Assert.That( result.HaveValues, Is.False );
		}

    }
}
