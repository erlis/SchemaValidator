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
        public void ToString_should_return_string_representation_for_missing_tables()
        {
            // Arrange
            SchemaSpecification spec1 = new SchemaSpecification();
            spec1.AddTable("TableName").WithColumn("Id").OfType("int", 4)
                                       .WithColumn("Desc").OfType("varchar", 100).Nullable()
                                       .GetTable();
            SchemaSpecification spec2 = new SchemaSpecification();

            CompareResult compareResult = spec1.Compare(spec2); 

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
            Table t1 = new Table("t1").WithColumn("Id").OfType("int", 4)
                                      .WithColumn("Desc").OfType("varchar", 100).Nullable()
                                      .GetTable();
            Table t2 = new Table("t1");

            CompareResult compareResult = t1.Compare(t2); 

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
        public void ToString_should_return_string_representation_for_conflict_columns()
        {
            // Arrange
            Table t1 = new Table("t1").WithColumn("column1").OfType("int", 4).GetTable();
            Table t2 = new Table("t1").WithColumn("column1").OfType("varchar", 4).GetTable();

            CompareResult compareResult = t1.Compare(t2); 

            string expected = "Conflict Column(s)\n" +
                              "----------------\n" +
                              "Expected: column1 : int(4)\n" +
                              "But was:  column1 : varchar(4)\n\n";

            // Act 
            string result = compareResult.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_should_return_string_representation_for_conflict_tables()
        {
            // Arrange
            SchemaSpecification spec1 = new SchemaSpecification();
            spec1.AddTable("t1").WithColumn("column1").OfType("int", 4)
                                .WithColumn("irrelevant").OfType("varchar", 1 ).Nullable()
                                .GetTable();

            SchemaSpecification spec2 = new SchemaSpecification();
            spec2.AddTable("t1").WithColumn("column1").OfType("varchar", 4)
                                .WithColumn("irrelevant").OfType("varchar", 1 ).Nullable()
                                .GetTable();

            CompareResult compareResult = spec1.Compare(spec2); 

            string expected = "Conflict Table(s)\n" +
                              "----------------\n" +
                              "[t1]\n" +    
                              "   Conflict Column(s)\n" +
                              "   ----------------\n" +
                              "   Expected: column1 : int(4)\n" +
                              "   But was:  column1 : varchar(4)\n\n";

            // Act 
            string result = compareResult.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
