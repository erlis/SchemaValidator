using NUnit.Framework;
using System;
using SchemaValidator.DbProviders;
using SchemaValidator.Specification;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.DbProviders
{
    [TestFixture]
    public class SqlSrvProviderTests
    {
        [Test]
        [Category("DB")]
        public void Constructor_should_accept_a_string_parameter()
        {
            // Act
            SqlSrvProvider db = new SqlSrvProvider(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        [Category("DB")]
        public void Constructor_should_fail_when_string_parameter_is_null()
        {
            // Act
            SqlSrvProvider db = new SqlSrvProvider(null);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        [Category("DB")]
        public void Constructor_should_fail_when_string_parameter_is_empty()
        {
            // Act
            SqlSrvProvider db = new SqlSrvProvider(string.Empty);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        [Category("DB")]
        public void LoadSchemaSpecification_should_throw_exception_when_connection_string_is_wrong()
        {
            // Arrange
            SqlSrvProvider db = new SqlSrvProvider(@"wrong database connection string");

            // Act
            SchemaSpecification scdb = db.LoadDbSpecification();
        }

        [Test]
        [Category("DB")]
        public void LoadSchemaSpecification_should_update_TableCount_property()
        {
            // Arrange
            SqlSrvProvider db = new SqlSrvProvider(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            SchemaSpecification scdb = db.LoadDbSpecification();

            // Assert
            Assert.That(Is.Equals(scdb.Tables.Count, 13));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        [Category("DB")]
        public void RequireTable_should_throw_exception_when_duplicated_table()
        {
            // Arrange
            SqlSrvProvider db = new SqlSrvProvider(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            DbSpecification scdb = db.LoadDbSpecification();

            // duplicated table
            scdb.AddTable("region");
        }

    }
}
