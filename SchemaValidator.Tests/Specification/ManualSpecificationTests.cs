using NUnit.Framework;
using SchemaValidator.Specification;
using SchemaValidator.ValueObjects.DBElements;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.Specification
{
    [TestFixture]
    public class ManualSpecificationTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(SpecificationException))]
        public void AssertIsSatisfiedBy_should_throw_exception_when_missing_tables()
        {
            // Arrange
            List<Table> tableList = new List<Table>
                                        {
                                            new Table( "irrelevant")
                                        };
            DBSpecification dbSpecification = new DBSpecification(tableList);
            ManualSpecification manualSpecification = new ManualSpecification();
            manualSpecification.AddTable("t1");


            // Act
            manualSpecification.AssertIsSatisfiedBy(dbSpecification); 
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(SpecificationException))]
        public void AssertIsSatisfiedBy_should_throw_exception_when_conflict_tables()
        {
            // Arrange
            List<Table> tableList = new List<Table>
                                        {
                                            new Table( "t1")
                                        };
            DBSpecification dbSpecification = new DBSpecification(tableList);
            ManualSpecification manualSpecification = new ManualSpecification();
            manualSpecification.AddTable("t1").WithColumn("c1");


            // Act
            manualSpecification.AssertIsSatisfiedBy(dbSpecification);
        }
    }
}
