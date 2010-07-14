using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    public class TableConflictTests
    {
        [TestFixture]
        public class WhenCreatingATableConflict
        {
            [Test]
            public void GivenAColumnPair_ThenFirstAndSecondAreDelegatesOfPair()
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
