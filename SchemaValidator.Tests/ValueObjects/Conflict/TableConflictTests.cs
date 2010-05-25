using NUnit.Framework;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    [TestFixture]
    public class TableConflictTests
    {

        [Test]
        public void Constructor_should_receive_a_Column_Pair()
        {
            // Arrange
            var pair = new Pair<Column>(Column.Create("irrelevant"), Column.Create("irrelevant"));

            // Act
            TableConflict conflict = new TableConflict(pair);

            // Assert
            Assert.That(conflict.First, Is.EqualTo(pair.First));
            Assert.That(conflict.Second, Is.EqualTo(pair.Second));
        }

    }
}
