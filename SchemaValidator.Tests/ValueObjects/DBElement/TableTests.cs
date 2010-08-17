using NUnit.Framework;
using System;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.DBElement
{
    public class TableTests
    {
        [TestFixture]
        public class When_creating
        {
            [Test] public void Given_null_as_table_name_then_should_fail()
            {
                // Assert
                Assert.Throws<ArgumentException>(() => new Table(null));
            }
        }

        [TestFixture]
        public class When_comparing
        {
            [Test] public void Should_have_same_table_names_to_be_a_valid_operation()
            {
                // Arrange
                Table t1 = new Table("t1");
                Table t2 = new Table("t1");

                // Act
                CompareResult result = t1.Compare(t2);

                // Assert
                Assert.That(result, Is.Not.Null);
            }

            [Test] public void Given_two_tables_with_different_columnType_then_conflict_should_be_detected()
            {
                // Arrange
                Table t1 = new Table("t1");
                Column expectedFirst = t1.WithColumn("c1").OfType("int", 4);
                t1.WithColumn("irrelevant").OfType("varchar", 3);

                Table t2 = new Table("t1");
                Column expectedSecond = t2.WithColumn("c1").OfType("varchar", 4);
                t2.WithColumn("irrelevant").OfType("varchar", 3);

                // Act 
                CompareResult result = t1.Compare(t2);

                // Assert
                Assert.That(result.ConflictList.Count, Is.EqualTo(1));
                Assert.That(result.ConflictList[0].First, Is.SameAs(expectedFirst));
                Assert.That(result.ConflictList[0].Second, Is.SameAs(expectedSecond));
            }

            [Test] public void Given_two_tables_with_different_names_then_should_throw_InvalidOperationException()
            {
                // Arrange
                Table t1 = new Table("t1");
                Table t2 = new Table("t2");

                // Act & Assert
                Assert.Throws<InvalidOperationException>(() => t1.Compare(t2));
            }

            [Test] public void Given_a_table_with_a_missing_column_then_the_missing_column_should_be_detected()
            {
                // Arrange
                Table t1 = new Table("t1");
                t1.WithColumn("c1");

                Table t2 = new Table("t1");

                // Act 
                CompareResult result = t1.Compare(t2);

                // Assert
                Assert.That(result.MissingList.Count, Is.EqualTo(1));
                Assert.That(result.MissingList[0].Name, Is.EqualTo("c1"));
            }
            
            [Test] public void Given_a_table_with_extra_columns_then_the_extra_columns_should_be_ignored()
            {
                // Arrange
                Table t1 = new Table("t1");
                t1.WithColumn("c1");

                Table t2 = new Table("t1");
                t2.WithColumn("c1");
                t2.WithColumn("c2");

                // Act
                CompareResult result = t1.Compare(t2);

                // Assert 
                Assert.That(result.HaveValues, Is.False);
            }

            [Test] public void Then_table_names_should_be_case_insensitive()
            {
                // Arrange
                Table t1 = new Table("T1");
                Table t2 = new Table("t1");

                // Act
                CompareResult result = t1.Compare(t2);

                // Assert
                Assert.That(result, Is.Not.Null);
            }

        }

        [TestFixture]
        public class Given_Table_should_be_fluent
        {
            [Test] public void Then_WithColumn_should_be_used_to_add_columns_to_a_table()
            {
                // Arrange
                Table table = new Table("table1");

                // Act 
                table.WithColumn("c1")
                     .WithColumn("c2")
                     .WithColumn("c3");

                // Assert
                Assert.That(table.Columns.Count, Is.EqualTo(3));
            }

            [Test] public void Then_WithColumn_should_create_a_new_column()
            {
                // Arrange
                Table table = new Table("table1");

                // Act
                Column column = table.WithColumn("Column1");

                // Assert
                Assert.That(column.Name, Is.EqualTo("Column1"));
            }

            [Test] public void When_twice_the_same_column_name_then_WithColumn_should_throw_ApplicationException()
            {
                // Arrange
                Table table = new Table("table1");

                // Act
            	Assert.Throws<ApplicationException>( () => table.WithColumn( "c1" )
            	                                     	        .WithColumn( "c1" ) );
            }

            [Test] public void When_twice_the_same_column_name_with_different_case_then_WithColumn_should_throw_ApplicationException()
            {
                // Arrange
                Table table = new Table("table1");

                // Act & Assert
                Assert.Throws<ApplicationException>(() => table.WithColumn("c1")
                                                              .WithColumn("C1"));
            }

            [Test] public void Then_Done_will_end_the_fluent_sequence_for_columns()
            {
                // Arrange
                Table table = new Table("Table1")
                    .WithColumn("column1")
                    .Done(); 

                // Assert
                Assert.That( table, Is.InstanceOf(typeof(Table)));
            }
        }

        [TestFixture]
        public class When_representing_as_string
        {
            [Test] public void Given_a_table_with_the_columns_then_ToString_should_return_string_representation()
            {
                // Arrange
                Table table = new Table("Person")
                    .WithColumn("Id").OfType("int", 4)
                    .WithColumn("Name").OfType("varchar", 255).Nullable()
                    .WithColumn("Salary").OfType("double", 2)
                    .Done();
                string expected = "[Person]\n" +
                                  "   Id : int(4)\n" +
                                  "   Name : varchar(255) NULLABLE\n" +
                                  "   Salary : double(2)\n";

                // Act
                string result = table.ToString();

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
