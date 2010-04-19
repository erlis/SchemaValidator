using NUnit.Framework;
using System;
using SchemaValidator.Specification;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.Specification
{
    [TestFixture]
    public class DBSpecificationTests
    {
        [Test]
        [Ignore]
        public void Constructor_should_expect_connectionString()
        {
            // Act
            DBSpecification dbSpecification = new DBSpecification(/*Connection String*/);
            int expected = 10; /* = number of tables */

            // Assert
            Assert.That(dbSpecification.TableCount, Is.EqualTo(expected));
        }

        [Test]
        [Ignore]
        public void AddTable_should_throw_exception()
        {
            // Arrange
            SchemaSpecification spec = new DBSpecification();

            // Act
            spec.AddTable("a table");
        }
    }
}
