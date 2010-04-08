using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class ColumnTests
    {

        [Test]
        public void WithColumn_should_return_class_Column()
        {
            // Arrange
            Column initial = new Column("c1", new Table("irrelevant"));

            // Act 
            Column actual = initial.WithColumn("c2");

            // Assert
            Assert.That(actual.Name, Is.EqualTo("c2"));
        }


        [Test]
        public void Equals_should_be_true_for_two_different_instances_when_all_fields_equals()
        {
            // Arrange
            Column column1 = new Column("c1", new Table("irrelevant"));
            Column column2 = new Column("c1", new Table("irrelevant"));

            // Assert
            Assert.That(column1.Equals(column2));
        }


        [Test]
        public void OfType_should_set_ColumnType_for_the_current_instance()
        {
            // Arrange 
            Column column = new Column("c1", new Table("irrelevant"));

            // Act
            column.OfType("int");

            // Assert
            Assert.That(column.ColumnType, Is.EqualTo("int"));
        }


        [Test]
        public void OfType_should_return_the_self_instance()
        {
            // Arrange 
            Column expected = new Column("c1", new Table("irrelevant"));

            // Act
            Column actual = expected.OfType("varchar");

            // Assert
            Assert.That(actual, Is.SameAs(expected));
        }


    }
}
