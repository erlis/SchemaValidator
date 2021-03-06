﻿using NUnit.Framework;
using SchemaValidator.ValueObjects.DBElements;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class ManualSpecificationTests
    {
        [Test]
        public void AssertIsSatisfiedBy_should_throw_exception_when_missing_tables()
        {
            // Arrange
            List<Table> tableList = new List<Table>
                                        {
                                            new Table( "irrelevant")
                                        };
            DbSpecification dbSpecification = new DbSpecification(tableList);
            ManualSpecification manualSpecification = new ManualSpecification();
            manualSpecification.RequireTable("t1");


            // Assert
            Assert.Throws<SpecificationException>(() => manualSpecification.AssertIsSatisfiedBy(dbSpecification));
        }

        [Test]
        public void AssertIsSatisfiedBy_should_throw_exception_when_conflict_tables()
        {
            // Arrange
            List<Table> tableList = new List<Table>
                                        {
                                            new Table( "t1")
                                        };
            DbSpecification dbSpecification = new DbSpecification(tableList);
            ManualSpecification manualSpecification = new ManualSpecification();
            manualSpecification.RequireTable("t1").WithColumn("c1");


            // Assert
            Assert.Throws<SpecificationException>(() => manualSpecification.AssertIsSatisfiedBy(dbSpecification));
        }
    }
}
