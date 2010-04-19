using System.Collections.Generic;
using NUnit.Framework;
using System;
using SchemaValidator.Specification;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.Specification
{
    [TestFixture]
    public class DBSpecificationTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void AddTable_should_throw_exception()
        {
            // Arrange
            SchemaSpecification spec = new DBSpecification(new List<Table>());

            // Act
            spec.AddTable("a table");
        }
    }
}
