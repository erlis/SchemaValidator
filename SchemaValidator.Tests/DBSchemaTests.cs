using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SchemaValidator.Tests
{
    [TestFixture]
    class DBSchemaTests
    {

        [Test]
        public void RequireTable_should_return_clase_Table()
        {
            // Arrange
            DBSchema dbSchema = new DBSchema();

            // Act
            Table result = dbSchema.RequireTable("TableName");

            // Assert
            Assert.That(result.Name, Is.EqualTo("TableName"));
        }
    }
}
