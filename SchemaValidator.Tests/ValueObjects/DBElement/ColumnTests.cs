using System;
using NUnit.Framework;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.DBElement
{
    public class ColumnTests
    {
        [TestFixture]
        public class When_creating
        {
            [ExpectedException(ExpectedException = typeof(ArgumentException))]
            [Test] public void Given_no_columnName_then_constructor_should_fail()
            {
                // Assert
                Column.Create(null);
            }

            [Test] public void Given_a_table_then_the_created_column_should_be_added_to_that_table()
            {
                // Arrange
                Table table = new Table("t1");

                // Act 
                Column column = Column.CreateWithTable("c1", table);

                // Assert
                Assert.That(table.Columns.Contains(column));
            }

            [Test] public void Then_IsNullable_should_be_false()
            {
                // Arrange
                Column column = Column.Create("c1");

                // Assert
                Assert.That(column.IsNullable, Is.False);
            }
        }

        [TestFixture]
        public class Equals_should_be_false
        {
            [Test] public void When_columnName_different()
            {
                // Arrange
                Column column1 = Column.Create("c1").OfType("int", 0).Nullable();
                Column column2 = Column.Create("c2").OfType("int", 0).Nullable();

                // Assert
                Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
                Assert.That(column1.Equals(column2), Is.False);
            }

            [Test] public void When_typeLength_different()
            {
                // Arrange
                Column column1 = Column.Create("c1").OfType("int", 0).Nullable();
                Column column2 = Column.Create("c1").OfType("int", 1).Nullable();

                // Assert
                Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
                Assert.That(column1.Equals(column2), Is.False);
            }

            [Test] public void When_typeName_different()
            {
                // Arrange
                Column column1 = Column.Create("c1").OfType("varchar", 0).Nullable();
                Column column2 = Column.Create("c1").OfType("int", 0).Nullable();

                // Assert
                Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
                Assert.That(column1.Equals(column2), Is.False);
            }

            [Test] public void When_IsNullable_different()
            {
                // Arrange
                Column column1 = Column.Create("c1").OfType("int", 0).Nullable();
                Column column2 = Column.Create("c1").OfType("int", 0);

                // Asert
                Assert.That(column1.GetHashCode(), Is.Not.EqualTo(column2.GetHashCode()));
                Assert.That(column1.Equals(column2), Is.False);
            }
        }

        [TestFixture]
        public class Equals_should_be_true
        {
            [Test] public void When_all_fields_equals_given_two_different_instances()
            {
                // Arrange
                Column column1 = Column.Create("c1").OfType("varchar", 0).Nullable();
                Column column2 = Column.Create("c1").OfType("varchar", 0).Nullable();

                // Assert
                Assert.That(column1.GetHashCode(), Is.EqualTo(column2.GetHashCode()));
                Assert.That(column1.Equals(column2));
            }

            [Test] public void When_fields_differ_only_by_case_sensitivity()
            {
                // Arrange
                Column column1 = Column.Create("C1").OfType("Varchar", 0);
                Column column2 = Column.Create("c1").OfType("varChar", 0);

                // Assert
                Assert.That(column1.GetHashCode(), Is.EqualTo(column2.GetHashCode()));
                Assert.That(column1.Equals(column2));
            }
        }

        [TestFixture]
        public class When_setting_column_as_nulleable
        {
            [Test] public void Then_self_instance_should_be_returned()
            {
                // Arrange 
                Column expected = Column.Create("c1");

                // Act
                Column actual = expected.Nullable();

                // Assert
                Assert.That(actual, Is.SameAs(expected));
            }

            [Test] public void Then_IsNullable_should_be_to_true()
            {
                // Arrange
                Column column = Column.Create("c1");
                Assert.That(column.IsNullable, Is.False);

                // Act
                column.Nullable();

                // Assert
                Assert.That(column.IsNullable, Is.True);
            }
        }

        [TestFixture]
        public class When_setting_column_type
        {
            [Test] public void Then_self_instance_should_be_returned()
            {
                // Arrange 
                Column expected = Column.Create("c1");

                // Act
                Column actual = expected.OfType("varchar", 0);

                // Assert
                Assert.That(actual, Is.SameAs(expected));
            }

            [Test] public void Then_ColumnLength_should_be_initialized()
            {
                // Arrange 
                Column column = Column.Create("c1");

                // Act
                column.OfType("int", 4);

                // Assert
                Assert.That(column.ColumnLength, Is.EqualTo(4));
            }

            [Test] public void Then_ColumnType_should_be_initialized()
            {
                // Arrange 
                Column column = Column.Create("c1");

                // Act
                column.OfType("int", 0);

                // Assert
                Assert.That(column.ColumnType, Is.EqualTo("int"));
            }
        }

        [TestFixture]
        public class Given_Column_should_be_fluent
        {
            [Test] public void Then_WithColumn_should_create_a_new_Column()
            {
                // Arrange
                Column initial = Column.CreateWithTable("c1", new Table("irrelevant"));

                // Act 
                Column actual = initial.WithColumn("c2");

                // Assert
                Assert.That(actual.Name, Is.EqualTo("c2"));
            }

            [Test] public void Then_WithColumn_should_add_returned_column_to_table()
            {
                // Arrange
                var table = new Table("irrelevant");
                Column initial = Column.CreateWithTable("c1", table);

                // Act 
                Column actual = initial.WithColumn("c2");

                // Assert
                Assert.That(table.Columns.Count, Is.EqualTo(2));
                Assert.That(table.Columns.Contains(actual));
            }

            [ExpectedException(ExpectedException = typeof(NullReferenceException))]
            [Test] public void Then_WithColumn_fails_when_no_table_associated()
            {
                // Arrange
                Column initial = Column.Create("c1");

                // Act 
                Column actual = initial.WithColumn("c2");

                // Assert
                Assert.That(actual.Name, Is.EqualTo("c2"));
            }
        }

        [TestFixture]
        public class When_representing_as_String
        {
            [Test] public void Given_a_nulleable_type_then_represent_type_information_and_NULLABLE_should_appear()
            {
                // Arrange
                Column column = Column.Create("c1").OfType("int", 4).Nullable();
                string expected = "c1 : int(4) NULLABLE";

                // Act
                string result = column.ToString();

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test] public void Given_a_not_nulleable_type_then_represent_type_information()
            {
                // Arrange
                Column column = Column.Create("c1").OfType("int", 4);
                string expected = "c1 : int(4)";

                // Act
                string result = column.ToString();

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }
        }

    }
}
