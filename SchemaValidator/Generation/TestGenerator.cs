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
            SqlSrvProvider dbSchema = new SqlSrvProvider(connectionString);
            _schemaSpecification = dbSchema.LoadDbSpecification();
        }

        public string GenerateTest()
        {
            string result = "using NUnit.Framework;\n" +
                            "using System\n" +
                            "\n" +
                            "namespace DatabaseTests {{ \n\n" +
                            "{0}[TestFixture]\n" +
                            "{0}public class DbSchemaTests {{\n" +
                            "{0}{0}private DbProvider dbProvider" +                            
                            "{0}\n" +
                            "{1}\n" +
                            "{2}\n" +
                            "{0}}}\n" +
                            "}} // namespace\n";

            string indent = "    ";
            string setup = GenerateSetup(indent+ "    ");
            string tests = GenerateTestMethods(indent+ "    ");
            return string.Format(result, indent, setup, tests);
        }

        private string GenerateSetup(string indent)
        {
            List<string> setUp = new List<string> {
                    "[SetUp]\n", 
                    "public void SetUp() {{\n",
                    "    // Arrange \n",
                    "}\n",
                };

            string result = "";
            setUp.ForEach( x => result += indent + x);
            return result;
        }


        private string GenerateTestMethods(string indent)
        {
            string result = "";
            foreach (var eachTable in _schemaSpecification.Tables)
            {
                List<string> test = new List<string> {
                                  "[Test]\n", 
                    string.Format("public void {0}_is_valid() {{\n", eachTable.Name),
                                  "    // Arrange \n",
                                  "    ManualSpecification manual = new ManualSpecification();\n",
                    string.Format("    manual.RequireTable(\"{0}\"){1};\n", eachTable.Name, GetColumns(indent + "        ", eachTable)),
                                  "}\n\n",
                };

                test.ForEach(x => result += indent + x);
            }

            return result;
        }

        private string GetColumns(string indent, Table table)
        {
            string result = "";
            foreach (var eachColumn in table.Columns)
            {
                result += string.Format("\n{0}.WithColumn(\"{1}\").OfType(\"{2}\", {3})", indent, eachColumn.Name, eachColumn.ColumnType, eachColumn.ColumnLength);
                if (eachColumn.IsNullable) result += ".Nulleable()";
            }
            return result;
        }
    }
}
