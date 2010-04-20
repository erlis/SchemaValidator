using NUnit.Framework;
using System;
using SchemaValidator.Specification;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class DatabaseSchemaTests
    {
        [Test]
        [Category("DB")]
        public void Constructor_should_accept_a_string_parameter()
        {
            // Act
            DatabaseSchema db = new DatabaseSchema(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        [Category("DB")]
        public void Constructor_should_fail_when_string_parameter_is_null()
        {
            // Act
            DatabaseSchema db = new DatabaseSchema(null);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        [Category("DB")]
        public void Constructor_should_fail_when_string_parameter_is_empty()
        {
            // Act
            DatabaseSchema db = new DatabaseSchema(string.Empty);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        [Category("DB")]
        public void LoadSchemaSpecification_should_throw_exception_when_connection_string_is_wrong()
        {
            // Arrange
            DatabaseSchema db = new DatabaseSchema(@"wrong database connection string");

            // Act
            SchemaSpecification scdb = db.LoadSchemaSpecification();
        }

        [Test]
        [Category("DB")]
        public void LoadSchemaSpecification_should_update_TableCount_property()
        {
            // Arrange
            DatabaseSchema db = new DatabaseSchema(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            SchemaSpecification scdb = db.LoadSchemaSpecification();

            // Assert
            Assert.That(Is.Equals(scdb.Tables.Count, 13));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        [Category("DB")]
        public void RequireTable_should_throw_exception_when_duplicated_table()
        {
            // Arrange
            DatabaseSchema db = new DatabaseSchema(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            SchemaSpecification scdb = db.LoadSchemaSpecification();

            // duplicated table
            scdb.AddTable("region");
        }

    }
}
