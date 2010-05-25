using NUnit.Framework;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    [TestFixture]
    public class SpecificationConflictTests
    {

        [Test]
        public void Constructor_should_receive_a_TablePair_with_Detail()
        {
            // Arrange
            var pair = new Pair<Table>(new Table("irrelevant"), new Table("irrelevant"));
            var compareResult = new CompareResult ();

            // Act
            var conflict = new SpecificationConflict( pair, compareResult);

            // Assert
            Assert.That( conflict.Detail, Is.SameAs(compareResult));
            Assert.That(conflict.First, Is.EqualTo(pair.First));
            Assert.That(conflict.Second, Is.EqualTo(pair.Second));
        }

    }
}
