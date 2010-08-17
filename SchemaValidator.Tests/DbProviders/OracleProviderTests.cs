using NUnit.Framework;
using System;
using SchemaValidator.DbProviders;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.DbProviders
{
    [TestFixture]
    [Category("DB")]
    public class OracleProviderTests
    {
        [Test]
        public void Constructor_should_accept_a_string_parameter()
        {
            // Act
            OracleProvider db = new OracleProvider(@"DATA SOURCE=DWQA;PERSIST SECURITY INFO=True;USER ID=ICRFSLDV;PASSWORD=icrfsldv;Pooling=FALSE", "ICRFSLDV");
        }

        [Test]
        public void Constructor_should_fail_when_connection_string_parameter_is_null()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>( () => new OracleProvider(null, "ICRFSLDV"));
        }

        [Test]
        public void Constructor_should_fail_when_connection_string_parameter_is_empty()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OracleProvider(string.Empty, "ICRFSLDV"));
        }

        [Test]
        public void Constructor_should_fail_when_owner_parameter_is_null()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OracleProvider(
                                                       @"DATA SOURCE=DWQA;PERSIST SECURITY INFO=True;USER ID=ICRFSLDV;PASSWORD=icrfsldv;Pooling=FALSE",
                                                       null));
        }

        [Test]
        public void Constructor_should_fail_when_owner_parameter_is_empty()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OracleProvider(
                                                       @"DATA SOURCE=DWQA;PERSIST SECURITY INFO=True;USER ID=ICRFSLDV;PASSWORD=icrfsldv;Pooling=FALSE",
                                                       string.Empty));
        }


        [Test]
        public void LoadSchemaSpecification_should_throw_exception_when_connection_string_is_wrong()
        {
            // Arrange
            OracleProvider db = new OracleProvider(@"wrong database connection string", "ICRFSLDV");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => db.LoadDbSpecification());
        }

        [Test]
        public void LoadSchemaSpecification_should_update_TableCount_property()
        {
            // Arrange
            OracleProvider db = new OracleProvider(@"DATA SOURCE=DWQA;PERSIST SECURITY INFO=True;USER ID=ICRFSLDV;PASSWORD=icrfsldv;Pooling=FALSE", "ICRFSLDV");

            // create schema specification 
            SchemaSpecification scdb = db.LoadDbSpecification();

            // Assert
            Assert.That(Is.Equals(scdb.Tables.Count, 143));
        }

    }
}
