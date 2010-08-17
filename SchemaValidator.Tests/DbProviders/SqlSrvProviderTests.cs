using NUnit.Framework;
using System;
using SchemaValidator.DbProviders;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.DbProviders
{
    [TestFixture]
    [Category("DB")]
    public class SqlSrvProviderTests
    {
        [Test]
        public void Constructor_should_accept_a_string_parameter()
        {
            // Act
            SqlSrvProvider db = new SqlSrvProvider(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");
        }

        [Test]
        public void Constructor_should_fail_when_string_parameter_is_null()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new SqlSrvProvider(null));
        }

        [Test]
        public void Constructor_should_fail_when_string_parameter_is_empty()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new SqlSrvProvider(string.Empty));
        }

        [Test]
        public void LoadSchemaSpecification_should_throw_exception_when_connection_string_is_wrong()
        {
            // Arrange
            SqlSrvProvider db = new SqlSrvProvider(@"wrong database connection string");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => db.LoadDbSpecification());
        }

        [Test]
        public void LoadSchemaSpecification_should_update_TableCount_property()
        {
            // Arrange
            SqlSrvProvider db = new SqlSrvProvider(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            SchemaSpecification scdb = db.LoadDbSpecification();

            // Assert
            Assert.That(Is.Equals(scdb.Tables.Count, 13));
        }

    }
}
