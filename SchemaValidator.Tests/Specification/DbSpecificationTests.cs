using System.Collections.Generic;
using NUnit.Framework;
using System;
using SchemaValidator.Specification;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.Specification
{
    [TestFixture]
    public class DbSpecificationTests
    {
        [Test]
        public void Constructor_should_initialize_by_receiving_table_list()
        {
            // Arrange
            List<Table> tableList = new List<Table>
                                        {
                                            new Table("t1"),
                                            new Table("t2"),
                                        };

            // Act
            DbSpecification dbSpecification = new DbSpecification(tableList);

            // Assert
            Assert.That(dbSpecification.TableCount, Is.EqualTo(2));
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void AddTable_should_throw_exception()
        {
            // Arrange
            SchemaSpecification spec = new DbSpecification(new List<Table>());

            // Act
            spec.AddTable("a table");
        }
    }
}
