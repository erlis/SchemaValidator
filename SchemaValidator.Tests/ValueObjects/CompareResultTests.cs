using NUnit.Framework;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects
{
    [TestFixture]
    public class CompareResultTests
    {
        [Test]
        public void HaveValue_should_be_false_when_no_value_added()
        {
            // Arrange 
            CompareResult compareResult = new CompareResult();

            // Assert
            Assert.That(compareResult.HaveValues, Is.False);
        }

        [Test]
        public void HaveValue_should_should_be_true_when_a_conflict_column_added()
        {
            // Arrange
            CompareResult compareResult = new CompareResult();
            var pair = new Pair(new Table("irrelevant"), new Table("irrelevant too"));
            compareResult.AddConflict(new Conflict(pair));

            // Assert
            Assert.That(compareResult.HaveValues, Is.True);
        }

        [Test]
        public void HaveValue_should_should_be_true_when_a_missing_column_added()
        {
            // Arrange
            CompareResult compareResult = new CompareResult();
            compareResult.AddMissing(new Column("irrelevant"));

            // Assert
            Assert.That(compareResult.HaveValues, Is.True);
        }
    }
}
