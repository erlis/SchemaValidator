using NUnit.Framework;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.SpecComparable;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects
{
    [TestFixture]
    public class ConflictTests
    {

        [Test]
        public void Constructor_should_receive_a_Column_Pair()
        {
            // Arrange
            Pair pair = new Pair(new Column("column1"), new Column("column2") );

            // Act
            Conflict conflict = new Conflict(pair);

            // Arrange
            Assert.That(conflict.First, Is.EqualTo(pair.First));
            Assert.That(conflict.Second, Is.EqualTo(pair.Second));
        }

        [Test]
        public void Constructor_should_receive_a_Table_Pair()
        {
            // Arrange
            Pair pair = new Pair(new Table("table1"), new Table("table2"));

            // Act
            Conflict conflict = new Conflict(pair);

            // Arrange
            Assert.That(conflict.First, Is.EqualTo(pair.First));
            Assert.That(conflict.Second, Is.EqualTo(pair.Second));
        }

    }
}
