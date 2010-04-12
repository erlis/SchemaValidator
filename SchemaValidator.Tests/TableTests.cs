using NUnit.Framework;
using System;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class TableTests
    {

        // private 
        private Table _table;


        [SetUp]
        public void SetUp()
        {
            _table = new Table("table1");
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Constructor_should_fail_when_tableName_null()
        {
            // Assert
            new Table(null);
        }
        
        [Test]
        public void Equals_should_be_true_for_two_different_instances()
        {
            // Arrange
            Table t1 = new Table( "" );
            Table t2 = new Table( "" );
            
            // Assert
            Assert.That( t1.Equals(t2), Is.True );
        }


        [Test]
        [Ignore]
        public void Equals_should_be_true_when_same_columns_specification()
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore]
        public void Equals_should_be_true_when_same_tableName()
        {
            throw new NotImplementedException();
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void WithColumn_should_be_case_insensitive()
        {
            // Act
            _table.WithColumn("c1")
                .WithColumn("C1");
        }

        [Test]
        public void WithColumn_should_be_concatenated_fluently()
        {
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
            // Act
            _table.WithColumn("c1");
            _table.WithColumn("c2");

            // Assert
            Assert.That(_table.ColumnCount, Is.EqualTo(2));
        }

        [Test]
        public void WithColumn_should_return_same_class_Table()
        {
            // Act
            Column column = _table.WithColumn("Column1");

            // Assert
            Assert.That(column.Name, Is.EqualTo("Column1"));
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void WithColumn_should_throw_exception_when_duplicated()
        {
            // Act
            _table.WithColumn("c1");
            _table.WithColumn("c1");
        }
    }
}
