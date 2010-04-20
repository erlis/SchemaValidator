using System;
using NUnit.Framework;
using SchemaValidator.Specification;
using SchemaValidator.ValueObjects;
using SchemaValidator.ValueObjects.DBElements;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests.Specification
{
    [TestFixture]
    public class SchemaSpecificationTests
    {
        private SchemaSpecification _schemaSpec;

        [SetUp]
        public void SetUp()
        {
            _schemaSpec = new SchemaSpecification();
        }


        [Test]
        public void AddTable_should_return_clase_Table()
        {
            // Act
            Table result = _schemaSpec.AddTable("TableName");

            // Assert
            Assert.That(result.Name, Is.EqualTo("TableName"));
        }


        [Test]
        public void AddTable_should_remember_previous_values()
        {
            // Act
            _schemaSpec.AddTable("Table1");
            _schemaSpec.AddTable("Table2");

            // Assert
            Assert.That(_schemaSpec.Tables.Count, Is.EqualTo(2));
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void AddTable_should_throw_exception_when_duplicated()
        {
            // Act 
            _schemaSpec.AddTable("Table1");
            _schemaSpec.AddTable("Table1");
        }


        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void AddTable_should_be_case_insensitive()
        {
            // Act
            _schemaSpec.AddTable("TabLe1");
            _schemaSpec.AddTable("taBle1");
        }

        [Test]
        public void Compare_should_detect_different_tables()
        {
            // Arrange
            SchemaSpecification spec1 = new SchemaSpecification();
            spec1.AddTable("t1");
            Table expectedFirst = spec1.AddTable("t2").WithColumn("c1").GetTable();

            SchemaSpecification spec2 = new SchemaSpecification();
            spec2.AddTable("t1");
            Table expectedSecond = spec2.AddTable("t2");

            // Act
            CompareResult result = spec1.Compare(spec2);

            // Assert
            Assert.That(result.ConflictList.Count, Is.EqualTo(1));
            Assert.That(result.ConflictList[0].First, Is.SameAs(expectedFirst));
            Assert.That(result.ConflictList[0].Second, Is.SameAs(expectedSecond));
        }

        [Test]
        public void Compare_should_detect_missing_tables()
        {
            // Arrange
            SchemaSpecification spec1 = new SchemaSpecification();
            spec1.AddTable("t1");
            Table expected = spec1.AddTable("t2");

            SchemaSpecification spec2 = new SchemaSpecification();
            spec2.AddTable("t1");

            // Act
            CompareResult result = spec1.Compare(spec2);

            // Assert
            Assert.That(result.MissingList.Count, Is.EqualTo(1));
            Assert.That(result.MissingList[0], Is.SameAs(expected));
        }

        [Test]
        public void Compare_should_ignore_extra_tables_in_the_other_specification()
        {
            // Arrange
            SchemaSpecification spec1 = new SchemaSpecification();
            spec1.AddTable("t1");

            SchemaSpecification spec2 = new SchemaSpecification();
            spec2.AddTable("t1");
            spec2.AddTable("t2");

            // Act
            CompareResult result = spec1.Compare(spec2);

            // Assert
            Assert.That(result.HaveValues, Is.False);
        }

        [Test]
        public void Compare_should_return_table_conflicts_with_their_columns_conflicts()
        {
            // Arrange
            SchemaSpecification spec1 = new SchemaSpecification();
            SchemaSpecification spec2 = new SchemaSpecification();

            spec1.AddTable("t1").WithColumn("t1_c1").OfType("int", 4);
            spec1.AddTable("t2").WithColumn("T2_c1").GetTable();

            spec2.AddTable("t1").WithColumn("t1_c1").OfType("varchar", 4);
            spec2.AddTable("t2");

            // Act
            CompareResult result = spec1.Compare(spec2);

            // Assert
            Assert.That(result.ConflictList.Count, Is.EqualTo(2));
            Conflict firstConflict = result.ConflictList[0];
            Assert.That(firstConflict.Detail, Is.Not.Null);

            var t1ColumnConflictList = firstConflict.Detail.ConflictList;
            Assert.That(t1ColumnConflictList.Count, Is.EqualTo(1));

            Assert.That(t1ColumnConflictList[0].First, Is.TypeOf<Column>());
            Assert.That(((Column)t1ColumnConflictList[0].First).ColumnType, Is.EqualTo("int"));
            Assert.That(((Column)t1ColumnConflictList[0].Second).ColumnType, Is.EqualTo("varchar"));

            // Asserting missing column 
            Conflict secondConflict = result.ConflictList[1];
            Assert.That(secondConflict.Detail, Is.Not.Null);
            var t2ColumnMissingList = secondConflict.Detail.MissingList;
            Assert.That(t2ColumnMissingList.Count, Is.EqualTo(1));
            Assert.That(t2ColumnMissingList[0], Is.TypeOf<Column>());
            Assert.That(t2ColumnMissingList[0].Name, Is.EqualTo("T2_c1"));
        }

    }
}
