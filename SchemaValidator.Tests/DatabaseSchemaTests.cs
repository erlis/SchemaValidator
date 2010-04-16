using NUnit.Framework;
using System;
using System.Collections.Generic;

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
        [Category("DB")]
        public void SchemaSpecification_should_be_created_if_the_string_connection_is_OK()
        {
            // Arrange
            DatabaseSchema db = new DatabaseSchema(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // Act
            SchemaSpecification scdb = db.LoadSchemaSpecification();

            // Assert
            Assert.That(scdb, Is.Not.Null);
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
            Assert.That(Is.Equals(scdb.TableCount, 13));
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
