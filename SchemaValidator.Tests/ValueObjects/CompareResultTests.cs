using NUnit.Framework;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

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
            CompareResult compareResult = new CompareResult();

            // Assert
            Assert.That(compareResult.HaveValues, Is.False);
        }

        [Test]
        public void HaveValue_should_should_be_true_when_a_conflict_column_added()
        {
            // Arrange
            CompareResult compareResult = new CompareResult();
            var pair = new Pair(new Table("irrelevant"), new Table("irrelevant too"));
            compareResult.AddConflict(new Conflict(pair));

            // Assert
            Assert.That(compareResult.HaveValues, Is.True);
        }

        [Test]
        public void HaveValue_should_should_be_true_when_a_missing_column_added()
        {
            // Arrange
            CompareResult compareResult = new CompareResult();
            compareResult.AddMissing(new Column("irrelevant"));

            // Assert
            Assert.That(compareResult.HaveValues, Is.True);
        }

        [Test]
        public void ToString_should_return_string_representation_for_missing()
        {
            // Arrange
            Table table = new Table("TableName").WithColumn("Id").OfType("int", 4)
                                                .WithColumn("Desc").OfType("varchar", 100).Nullable()
                                                .GetTable();
            CompareResult compareResult = new CompareResult();
            compareResult.AddMissing(table);
            string expected = "Missing Table(s)\n" +
                              "----------------\n" +
                              "[TableName]\n" +
                              "   Id : int(4)\n" +
                              "   Desc : varchar(100) NULLABLE\n\n";

            // Act 
            string result = compareResult.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_should_return_string_representation_for_missing_columns()
        {
            // Arrange
            Column column1 = new Column("Id").OfType("int", 4);
            Column column2 = new Column("Desc").OfType("varchar", 100).Nullable();

            CompareResult compareResult = new CompareResult();
            compareResult.AddMissing(column1);
            compareResult.AddMissing(column2);

            string expected = "Missing Column(s)\n" +
                              "----------------\n" +
                              "Id : int(4)\n" +
                              "Desc : varchar(100) NULLABLE\n";

            // Act 
            string result = compareResult.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore]
        public void ToString_should_return_string_representation_for_conflicts()
        {
            
        }

        [Test]
        [Ignore]
        public void ToString_should_return_string_representation_for_nested_details()
        {
            
        }
    }
}
