using System;
using NUnit.Framework;
using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class SchemaSpecificationTests
    {
        protected class TestingSchemaSpecification : SchemaSpecification
        {
            public new Table AddTable(string name)
            {
                return base.AddTable(name);
            }

            public new CompareResult Compare(SchemaSpecification specification)
            {
                return base.Compare(specification);
            }
        }

        [TestFixture]
        public class When_adding_a_table
        {
            private TestingSchemaSpecification _testingSchemaSpec;

            [SetUp]
            public void SetUp()
            {
                _testingSchemaSpec = new TestingSchemaSpecification();
            }

            [Test]
            public void Given_a_table_name_then_should_return_clase_Table_with_name()
            {
                // Act
                Table result = _testingSchemaSpec.AddTable("TableName");

                // Assert
                Assert.That(result.Name, Is.EqualTo("TableName"));
            }

            [Test]
            public void Given_two_table_names_then_both_should_be_remembered()
            {
                // Act
                _testingSchemaSpec.AddTable("Table1");
                _testingSchemaSpec.AddTable("Table2");

                // Assert
                Assert.That(_testingSchemaSpec.Tables.Count, Is.EqualTo(2));
            }

            [Test]
            public void Given_a_duplicate_table_name_then_should_throw_ApplicationException()
            {
                // Act 
                _testingSchemaSpec.AddTable("Table1");

                // Assert
                Assert.Throws<ApplicationException>(() => _testingSchemaSpec.AddTable("Table1"));
            }

            [Test]
            public void Then_table_name_should_be_case_insensitive()
            {
                // Act
                _testingSchemaSpec.AddTable("TabLe1");

                // Assert 
                Assert.Throws<ApplicationException>(() => _testingSchemaSpec.AddTable("taBle1"));
            }
        }

        [TestFixture]
        public class When_comparing 
        {
            [Test]
            public void Given_two_specifications_with_differences_in_one_table_then_conflict_should_be_detected()
            {
                // Arrange
                TestingSchemaSpecification spec1 = new TestingSchemaSpecification();
                spec1.AddTable("irrelevant");
                Table expectedFirst = spec1.AddTable("t2").WithColumn("c1").Done();

                TestingSchemaSpecification spec2 = new TestingSchemaSpecification();
                spec2.AddTable("irrelevant");
                Table expectedSecond = spec2.AddTable("t2");

                // Act
                CompareResult result = spec1.Compare(spec2);

                // Assert
                Assert.That(result.ConflictList.Count, Is.EqualTo(1));
                Assert.That(result.ConflictList[0].First, Is.SameAs(expectedFirst));
                Assert.That(result.ConflictList[0].Second, Is.SameAs(expectedSecond));
            }

            [Test]
            public void Given_a_specification_with_a_missing_table_then_the_missing_table_should_be_detected()
            {
                // Arrange
                TestingSchemaSpecification spec1 = new TestingSchemaSpecification();
                spec1.AddTable("t1");
                Table expected = spec1.AddTable("t2");

                TestingSchemaSpecification spec2 = new TestingSchemaSpecification();
                spec2.AddTable("t1");

                // Act
                CompareResult result = spec1.Compare(spec2);

                // Assert
                Assert.That(result.MissingList.Count, Is.EqualTo(1));
                Assert.That(result.MissingList[0], Is.SameAs(expected));
            }

            [Test]
            public void Given_a_specification_with_extra_tables_then_the_extra_tables_should_be_ignored()
            {
                // Arrange
                TestingSchemaSpecification spec1 = new TestingSchemaSpecification();
                spec1.AddTable("t1");

                TestingSchemaSpecification spec2 = new TestingSchemaSpecification();
                spec2.AddTable("t1");
                spec2.AddTable("t2");

                // Act
                CompareResult result = spec1.Compare(spec2);

                // Assert
                Assert.That(result.HaveValues, Is.False);
            }

            [Test]
            public void Then_should_return_table_conflicts_with_their_columns_conflicts()
            {
                // Arrange
                TestingSchemaSpecification spec1 = new TestingSchemaSpecification();
                TestingSchemaSpecification spec2 = new TestingSchemaSpecification();

                spec1.AddTable("t1").WithColumn("t1_c1").OfType("int", 4);
                spec1.AddTable("t2").WithColumn("T2_c1").Done();

                spec2.AddTable("t1").WithColumn("t1_c1").OfType("varchar", 4);
                spec2.AddTable("t2");

                // Act
                CompareResult result = spec1.Compare(spec2);

                // Assert
                Assert.That(result.ConflictList.Count, Is.EqualTo(2));
                var firstConflict = result.ConflictList[0];
                Assert.That(firstConflict.Detail, Is.Not.Null);

                var t1ColumnConflictList = firstConflict.Detail.ConflictList;
                Assert.That(t1ColumnConflictList.Count, Is.EqualTo(1));

                Assert.That(t1ColumnConflictList[0].First, Is.TypeOf<Column>());
                Assert.That(((Column)t1ColumnConflictList[0].First).ColumnType, Is.EqualTo("int"));
                Assert.That(((Column)t1ColumnConflictList[0].Second).ColumnType, Is.EqualTo("varchar"));

                // Asserting missing column 
                var secondConflict = result.ConflictList[1];
                Assert.That(secondConflict.Detail, Is.Not.Null);
                var t2ColumnMissingList = secondConflict.Detail.MissingList;
                Assert.That(t2ColumnMissingList.Count, Is.EqualTo(1));
                Assert.That(t2ColumnMissingList[0], Is.TypeOf<Column>());
                Assert.That(t2ColumnMissingList[0].Name, Is.EqualTo("T2_c1"));
            }

        }

    }
}
