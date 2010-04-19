using NUnit.Framework;
using SchemaValidator.Specification;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.Specification
{
    [TestFixture]
    public class ManualSpecificationTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(SpecificationException))]
        [Ignore]
        public void Validate_should_throw_exception_when_compare_has_values()
        {
            // Arrange
            ManualSpecification manualSpecification = new ManualSpecification();

            // Act
            manualSpecification.Validate(null /*DBSpecification*/); 
        }
    }
}
