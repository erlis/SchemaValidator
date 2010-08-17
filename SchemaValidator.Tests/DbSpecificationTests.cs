using System.Collections.Generic;
using NUnit.Framework;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{

    public class DbSpecificationTests
    {

        [TestFixture]
        public class When_creating
        {

            [Test]
            public void Instance_is_initialized_Given_a_table_list()
            {
                // Arrange
                List<Table> tableList = new List<Table>
                                        {
                                            new Table("t1"),
                                            new Table("t2"),
                                        };

                // Act
                DbSpecification dbSpecification = new DbSpecification(tableList);

                // Assert
                Assert.That(dbSpecification.Tables.Count, Is.EqualTo(2));
            }

        }

    }
}
