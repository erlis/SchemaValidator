using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    [TestFixture]
    public class PairTests
    {
        [Test]
        public void Constructor_should_allow_two_columns()
        {
            // Arrange 
            Column column1 = Column.Create("column1");
            Column column2 = Column.Create("column2");

            // Act 
            var pair = new Pair<Column>(column1, column2);

            // Assert
            Assert.That(pair.First, Is.SameAs(column1));
            Assert.That(pair.Second, Is.SameAs(column2));
        }

        [Test]
        public void Constructor_should_allow_two_Tables()
        {
            // Arrange 
            Table table1 = new Table("table1");
            Table table2 = new Table("table2");

            // Act 
            var pair = new Pair<Table>(table1, table2);

            // Assert
            Assert.That(pair.First, Is.SameAs(table1));
            Assert.That(pair.Second, Is.SameAs(table2));
        }

    }
}
