using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    public class SpecificationConflictTests
    {

        [TestFixture]
        public class When_creating
        {
            [Test]
            public void Given_a_tablePair_and_a_CompareResult_then_First_Second_and_Detail_delegates_on_them()
            {
                // Arrange
                var pair = new Pair<Table>(new Table("irrelevant"), new Table("irrelevant"));
                var compareResult = new CompareResult();

                // Act
                var conflict = new SpecificationConflict(pair, compareResult);

                // Assert
                Assert.That(conflict.Detail, Is.SameAs(compareResult));
                Assert.That(conflict.First, Is.EqualTo(pair.First));
                Assert.That(conflict.Second, Is.EqualTo(pair.Second));
            }
        }

    }
}
