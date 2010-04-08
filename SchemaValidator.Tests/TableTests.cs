using NUnit.Framework;

namespace SchemaValidator.Tests
{
    [TestFixture]
    public class TableTests
    {

        [Test]
        public void WithColumn_should_return_class_Column()
        {
            // Arrange
            Table table = new Table("table1"); 

            // Act
            Column column = table.WithColumn( "Column1" ); 

            // Assert
            Assert.That(column.Name, Is.EqualTo( "Column1" )); 
        }


    }
}
