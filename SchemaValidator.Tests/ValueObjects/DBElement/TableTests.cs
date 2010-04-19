using NUnit.Framework;
using System;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.DBElement
{
    [TestFixture]
    public class TableTests
    {
        [Test]
        public void Compare_should_allow_same_tableNames()
        {
            // Arrange
            Table t1 = new Table("t1");
            Table t2 = new Table("t1");

            // Act
            CompareResult result = t1.Compare(t2);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Compare_should_be_case_insensitive()
        {
            // Arrange
            Table t1 = new Table("T1");
            Table t2 = new Table("t1");

            // Act
            CompareResult result = t1.Compare(t2);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Compare_should_detect_different_columns()
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
			Assert.That( result.ConflictList[ 0 ].Second, Is.SameAs( expectedSecond ) );
		}

        [Test]
        public void Compare_should_detect_missing_columns()
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

        [Test]
        public void Compare_should_ignore_extra_columns_in_other_table()
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

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void Compare_should_throw_exception_when_different_tableNames()
        {
            // Arrange
            Table t1 = new Table("t1");
            Table t2 = new Table("t2");

            // Act
            t1.Compare(t2);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Constructor_should_fail_when_tableName_null()
        {
            // Assert
            new Table(null);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void WithColumn_should_be_case_insensitive()
        {
            // Arrange
            Table _table = new Table("table1");

            // Act
            _table.WithColumn("c1")
                  .WithColumn("C1");
        }

        [Test]
        public void WithColumn_should_be_concatenated_fluently()
        {
            // Arrange
            Table _table = new Table("table1");

            // Act 
            _table.WithColumn("c1")
                  .WithColumn("c2")
                  .WithColumn("c3");

            // Assert
            Assert.That(_table.ColumnCount, Is.EqualTo(3));
        }

        [Test]
        public void WithColumn_should_remember_previous_values()
        {
            // Arrange
            Table _table = new Table("table1");

            // Act
            _table.WithColumn("c1");
            _table.WithColumn("c2");

            // Assert
            Assert.That(_table.ColumnCount, Is.EqualTo(2));
        }

        [Test]
        public void WithColumn_should_return_same_class_Table()
        {
            // Arrange
            Table _table = new Table("table1");

            // Act
            Column column = _table.WithColumn("Column1");

            // Assert
            Assert.That(column.Name, Is.EqualTo("Column1"));
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void WithColumn_should_throw_exception_when_duplicated()
        {
            // Arrange
            Table _table = new Table("table1");

            // Act
            _table.WithColumn("c1");
            _table.WithColumn("c1");
        }
    }
}
