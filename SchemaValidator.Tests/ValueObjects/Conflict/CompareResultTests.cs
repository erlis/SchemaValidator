using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.ValueObjects.Conflict
{
    [TestFixture]
    public class CompareResultTests
    {
        [TestFixture]
        public class Should_have_some_value
        {
            [Test]
            public void When_a_conflict_column_added()
            {
                // Arrange
                CompareResult compareResult = new CompareResult();
                var pair = new Pair<Table>(new Table("irrelevant"), new Table("irrelevant too"));
                compareResult.AddConflict(new SpecificationConflict(pair)); //todo: good candidate for mock

                // Assert
                Assert.That(compareResult.HaveValues, Is.True);
            }

            [Test]
            public void When_a_missing_column_added()
            {
                // Arrange
                CompareResult compareResult = new CompareResult();
                compareResult.AddMissing(Column.Create("irrelevant"));

                // Assert
                Assert.That(compareResult.HaveValues, Is.True);
            }
        }

        [TestFixture]
        public class Should_not_have_any_value
        {
            [Test]
            public void When_no_value_added()
            {
                // Arrange 
                CompareResult compareResult = new CompareResult();

                // Assert
                Assert.That(compareResult.HaveValues, Is.False);
            }
        }

        //TODO: el metodo ToString() esta haciendo mucho. Este metodo va en otra clase que se encarga de 
        // imprimir un CompareResult. 
        [Test]
        public void ToString_should_return_string_representation_for_missing_tables()
        {
            // Arrange
            ManualSpecification spec1 = new ManualSpecification();
            spec1.RequireTable("TableName").WithColumn("Id").OfType("int", 4)
                                           .WithColumn("Desc").OfType("varchar", 100).Nullable()
                                           .Done();
            ManualSpecification spec2 = new ManualSpecification();

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
                                      .Done();
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
            Table t1 = new Table("t1").WithColumn("column1").OfType("int", 4).Done();
            Table t2 = new Table("t1").WithColumn("column1").OfType("varchar", 4).Done();

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
            ManualSpecification spec1 = new ManualSpecification();
        	spec1.RequireTable( "t1" ).WithColumn( "column1" ).OfType( "int", 4 )
        		                      .WithColumn( "irrelevant" ).OfType( "varchar", 1 ).Nullable();
                                

            ManualSpecification spec2 = new ManualSpecification();
        	spec2.RequireTable( "t1" ).WithColumn( "column1" ).OfType( "varchar", 4 )
                                      .WithColumn( "irrelevant" ).OfType( "varchar", 1 ).Nullable();
                                
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
