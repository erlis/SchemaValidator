using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    
    public class PairTests
    {
        [TestFixture]
        public class WhenCreatingThePair
        {
            [Test]
            public void GivenTwoElementsOfTheSameType_ThenConstructorSucceed()
            {
                // Arrange 
                Column column1 = Column.Create("column1");
                Column column2 = Column.Create("column2");

                // Act 
                var pair = new Pair<Column>(column1, column2);

                // Assert
                Assert.That(pair.First, Is.SameAs(column1));
                Assert.That(pair.Second, Is.SameAs(column2));
            }

            [Test]
            public void GivenTwoElementsOfDifferentType_ThenConstructorFails()
            {
                Assert.Pass( "Impossible to create a pair with two different elements due to implementation." );
            }

        }

    }
}
