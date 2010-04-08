using NUnit.Framework;

namespace SchemaValidator.Tests
{
    [TestFixture]
    class DBSchemaTests
    {
        private DBSchema _dbSchema; 

        [SetUp]
        public void SetUp()
        {
            _dbSchema = new DBSchema();
        }


        [Test]
        public void RequireTable_should_return_clase_Table()
        {
            // Act
            Table result = _dbSchema.RequireTable("TableName");

            // Assert
            Assert.That(result.Name, Is.EqualTo("TableName"));
        }


        [Test]
        public void RequireTable_should_remember_previous_values()
        {
            // Act
            _dbSchema.RequireTable("Table1");
            _dbSchema.RequireTable("Table2"); 

            // Assert
            Assert.That(_dbSchema.TableCount, Is.EqualTo(2)); 
        }


        [Test]
        public void RequireTable_should_avoid_duplicated_tablename()
        {
            // Act 
            _dbSchema.RequireTable("Table1");
            _dbSchema.RequireTable("Table1"); 

            // Assert
            Assert.That(_dbSchema.TableCount, Is.EqualTo(1)); 
        }


    }
}
