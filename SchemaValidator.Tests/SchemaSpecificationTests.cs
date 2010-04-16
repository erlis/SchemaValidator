using System;
using NUnit.Framework;
using SchemaValidator.ValueObjects;

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
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void RequireTable_should_throw_exception_when_duplicated()
        {
            // Act 
            _schemaSpec.RequireTable("Table1");
            _schemaSpec.RequireTable("Table1"); 
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void RequireTable_should_be_case_insensitive()
        {
            // Act
            _schemaSpec.RequireTable("TabLe1");
            _schemaSpec.RequireTable("taBle1"); 
        }

    }
}
