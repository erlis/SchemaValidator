using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class ColumnTests
    {
        [Test]
        public void Equals_should_be_case_insensitive()
        {
            // Arrange
            Column column1 = new Column("C1").OfType("Varchar");
            Column column2 = new Column("c1").OfType("varChar");

            // Assert
            Assert.That(column1.Equals(column2));
        }

        [Test]
        public void Equals_should_be_true_for_two_different_instances_when_all_fields_equals()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("varchar");
            Column column2 = new Column("c1").OfType("varchar");

            // Assert
            Assert.That(column1.Equals(column2));
        }


        [Test]
        public void Equals_should_be_false_when_only_columnName_different()
        {
            // Arrange
            Column column1 = new Column("c1");
            Column column2 = new Column("c2");

            // Assert
            Assert.That(column1.Equals(column2), Is.False);
        }


        [Test]
        public void Equals_should_be_false_when_only_type_different()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("varchar");
            Column column2 = new Column("c1").OfType("int");

            // Assert
            Assert.That( column1.Equals(column2), Is.False );
        }


        [Test]
        public void OfType_should_set_ColumnType_for_the_current_instance()
        {
            // Arrange 
            Column column = new Column("c1");

            // Act
            column.OfType("int");

            // Assert
            Assert.That(column.ColumnType, Is.EqualTo("int"));
        }


        [Test]
        public void OfType_should_return_the_self_instance()
        {
            // Arrange 
            Column expected = new Column("c1");

            // Act
            Column actual = expected.OfType("varchar");

            // Assert
            Assert.That(actual, Is.SameAs(expected));
        }

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
    }
}
