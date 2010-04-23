using System;
using SchemaValidator.Specification;
using System.Collections.Generic;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.Generation
{
    public class TestGenerator
    {
        // private 
        private SchemaSpecification _schemaSpecification;

        public TestGenerator(string connectionString)
        {
            DbProvider dbSchema = new DbProvider(connectionString);
            _schemaSpecification = dbSchema.LoadSchemaSpecification();
        }

        public string GenerateTest()
        {
            string result = "using NUnit.Framework;\n" +
                            "using System\n" +
                            "\n" +
                            "namespace DatabaseTests { \n" +
                            "    [TestFixture] public class PairTests {" +
                            "    \n" +
                            "    {0}" +
                            "    }" +
                            "} // namespace";
            return string.Format(result, GetTests());
        }


        private string GetTests()
        {
            string result = "";
            foreach (var eachTable in _schemaSpecification.Tables)
            {
                List<string> test = new List<string> {
                    string.Format("[Test] public void {0}_is_valid() {\n", eachTable.Name),
                                  "    // Arrange \n",
                                  "    ManualSpecification manual = new ManualSpecification();",
                    string.Format("    manual.RequireTable(\"{0}\"){1};", eachTable.Name, GetColumns(eachTable)),
                    "}\n\n"
                };

                test.ForEach( x => result += "    " + x);
            }

            return result;
        }

        private string GetColumns(Table table)
        {
            string result = ""; 
            foreach (var eachColumn in table.Columns)
            {
                result += string.Format("\n          .WithColumn(\"{0}\").OfType(\"{1}\", {2})", eachColumn.Name, eachColumn.ColumnType, eachColumn.ColumnLength);
                if (eachColumn.IsNullable)
                    result += ".Nulleable()"; 
            }
            return result; 
        }
    }
}
