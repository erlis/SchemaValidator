using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SchemaValidator.Tests
{
    [TestFixture]
    public class ColumnTests
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void WithColumn_should_return_class_Column()
        {
            // Arrange
            Table _table = new Table("t1");
            Column _column = _table.WithColumn("c1"); 

            // Act 
            Column actual = _column.WithColumn("c2"); 

            // Assert
            Assert.That(actual.Name, Is.EqualTo("c2")); 
        }
    }
}
