using NUnit.Framework;
using System;

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
        public void WithColumn_should_return_same_class_Table()
        {
            // Act
            Column column = _table.WithColumn("Column1");

            // Assert
            Assert.That(column.Name, Is.EqualTo("Column1"));
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
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void WithColumn_should_throw_exception_when_duplicated()
        {
            // Act
            _table.WithColumn("c1");
            _table.WithColumn("c1");
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


    }
}
