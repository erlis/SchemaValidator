using NUnit.Framework;
using SchemaValidator.ValueObjects.DBElements;
using SchemaValidator.ValueObjects;
using System;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects
{
    [TestFixture]
    public class PairTests
    {
        [Test]
        public void Constructor_should_allow_two_columns()
        {
            // Arrange 
            Column column1 = new Column("column1");
            Column column2 = new Column("column2");

            // Act 
            Pair pair = new Pair(column1, column2);

            // Assert
            Assert.That( pair.First, Is.SameAs( column1));
            Assert.That(pair.Second, Is.SameAs(column2));
        }

        [Test]
        public void Constructor_should_allow_two_Tables()
        {
            // Arrange 
            Table table1 = new Table("table1");
            Table table2 = new Table("table2");

            // Act 
            Pair pair = new Pair(table1, table2);

            // Assert
            Assert.That(pair.First, Is.SameAs(table1));
            Assert.That(pair.Second, Is.SameAs(table2));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Constructor_should_throw_exception_when_different_types()
        {
            // Arrange
            Table table = new Table("table");
            Column column = new Column("column");

            // Act
            Pair pair = new Pair(table, column);
        }
    }
}
