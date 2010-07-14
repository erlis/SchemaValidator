using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    public class TableConflictTests
    {
        [TestFixture]
        public class When_creating
        {
            [Test]
            public void Given_a_columnPair_then_First_and_Second_delegates_on_them()
            {
                // Arrange
                var pair = new Pair<Column>(
                    Column.Create("irrelevant"),
                    Column.Create("irrelevant")
                );

                // Act
                TableConflict conflict = new TableConflict(pair);

                // Assert
                Assert.That(conflict.First, Is.EqualTo(pair.First));
                Assert.That(conflict.Second, Is.EqualTo(pair.Second));
            }
        }


    }
}
