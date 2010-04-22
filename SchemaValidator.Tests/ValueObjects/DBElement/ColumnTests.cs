using System;
using NUnit.Framework;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.DBElement
{
    [TestFixture]
    public class ColumnTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Constructor_should_fail_when_columnName_null()
        {
            // Assert
            new Column(null);
        }


        [Test]
        public void Equals_should_be_case_insensitive()
        {
            // Arrange
            Column column1 = new Column("C1").OfType("Varchar", 0);
            Column column2 = new Column("c1").OfType("varChar", 0);

            // Assert
            Assert.That(column1.GetHashCode(), Is.EqualTo(column2.GetHashCode()));
            Assert.That(column1.Equals(column2));
        }


        [Test]
        public void Equals_should_be_false_when_only_columnName_different()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("int", 0).Nullable();
            Column column2 = new Column("c2").OfType("int", 0).Nullable();

            // Assert
            Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
            Assert.That(column1.Equals(column2), Is.False);
        }


        [Test]
        public void Equals_should_be_false_when_only_typeLength_different()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("int", 0).Nullable();
            Column column2 = new Column("c1").OfType("int", 1).Nullable();

            // Assert
            Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
            Assert.That(column1.Equals(column2), Is.False);
        }

        [Test]
        public void Equals_should_be_false_when_only_typeName_different()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("varchar", 0).Nullable();
            Column column2 = new Column("c1").OfType("int", 0).Nullable();

            // Assert
            Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
            Assert.That(column1.Equals(column2), Is.False);
        }

        [Test]
        public void Equals_should_be_false_when_only_IsNullable_different()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("int", 0).Nullable();
            Column column2 = new Column("c1").OfType("int", 0);

            // Asert
            Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
            Assert.That(column1.Equals(column2), Is.False);
        }

        [Test]
        public void Equals_should_be_true_for_two_different_instances_when_all_fields_equals()
        {
            // Arrange
            Column column1 = new Column("c1").OfType("varchar", 0).Nullable();
            Column column2 = new Column("c1").OfType("varchar", 0).Nullable();

            // Assert
            Assert.That(column1.GetHashCode(), Is.EqualTo(column2.GetHashCode()));
            Assert.That(column1.Equals(column2));
        }

        [Test]
        public void IsNullable_should_be_false_by_default()
        {
            // Arrange
            Column column = new Column("c1");

            // Assert
            Assert.That(column.IsNullable, Is.False);
        }

        [Test]
        public void Nullable_should_return_the_self_instance()
        {
            // Arrange 
            Column expected = new Column("c1");

            // Act
            Column actual = expected.Nullable();

            // Assert
            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void Nullable_should_set_IsNullable_for_the_current_instance()
        {
            // Arrange
            Column column = new Column("c1");
            Assert.That(column.IsNullable, Is.False);

            // Act
            column.Nullable();

            // Assert
            Assert.That(column.IsNullable, Is.True);
        }

        [Test]
        public void OfType_should_return_the_self_instance()
        {
            // Arrange 
            Column expected = new Column("c1");

            // Act
            Column actual = expected.OfType("varchar", 0);

            // Assert
            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void OfType_should_set_ColumnLength_for_the_current_instance()
        {
            // Arrange 
            Column column = new Column("c1");

            // Act
            column.OfType("int", 4);

            // Assert
            Assert.That(column.ColumnLength, Is.EqualTo(4));
        }

        [Test]
        public void OfType_should_set_ColumnType_for_the_current_instance()
        {
            // Arrange 
            Column column = new Column("c1");

            // Act
            column.OfType("int", 0);

            // Assert
            Assert.That(column.ColumnType, Is.EqualTo("int"));
        }

        [Test]
        public void ToString_should_return_string_representation_when_nulleable()
        {
            // Arrange
            Column column = new Column("c1").OfType("int", 4).Nullable();
            string expected = "c1 : int(4) NULLABLE";

            // Act
            string result = column.ToString(); 

            // Assert
            Assert.That( result, Is.EqualTo(expected));
        }


        [Test]
        public void ToString_should_return_string_representation_when_not_nulleable()
        {
            // Arrange
            Column column = new Column("c1").OfType("int", 4);
            string expected = "c1 : int(4)";

            // Act
            string result = column.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WithColumn_should_return_class_Column()
        {
            // Arrange
            Column initial = new Column("c1");

            // Act 
            Column actual = initial.WithColumn("c2");

            // Assert
            Assert.That(actual.Name, Is.EqualTo("c2"));
        }
    }
}
