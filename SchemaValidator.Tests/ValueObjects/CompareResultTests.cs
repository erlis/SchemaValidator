﻿using NUnit.Framework;
using SchemaValidator.ValueObjects;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects
{
    [TestFixture]
    public class CompareResultTests
    {
        [Test]
        public void HaveValue_should_be_false_when_no_value_added()
        {
            // Arrange 
            CompareResult<string> compareResult = new CompareResult<string>();

            // Assert
            Assert.That(compareResult.HaveValues, Is.False);
        }

        [Test]
        public void HaveValue_should_should_be_true_when_a_conflict_column_added()
        {
            // Arrange
            CompareResult<string> compareResult = new CompareResult<string>();
            compareResult.AddConflictColumn("");

            // Assert
            Assert.That(compareResult.HaveValues, Is.True);
        }

        [Test]
        public void HaveValue_should_should_be_true_when_a_missing_column_added()
        {
            // Arrange
            CompareResult<string> compareResult = new CompareResult<string>();
            compareResult.AddMissingColumn("");

            // Assert
            Assert.That(compareResult.HaveValues, Is.True);
        }
    }
}
