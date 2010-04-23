using SchemaValidator.DbProviders;
using System.Collections.Generic;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.Generation
{
    public class TestGenerator
    {
        // private 
        private SchemaSpecification _schemaSpecification;
        private string _connectionString; 

        public TestGenerator(string connectionString)
        {
            _connectionString = connectionString; 
            SqlSrvProvider dbSchema = new SqlSrvProvider(connectionString);
            _schemaSpecification = dbSchema.LoadDbSpecification();
        }

        public string GenerateTest()
        {
            return "using NUnit.Framework;\n" +
                   "using System;\n" +
                   "\n" +
                   "namespace DatabaseTests { \n\n" +
                   "    [TestFixture]\n" +
                   "    public class DbSchemaTests {\n" +
                   "        private DbSpecification _dbSpecification;\n" +
                   "\n" +
                   GenerateSetup("        ") + "\n" +
                   "\n" +
                   GenerateTestMethods("        ") + "\n" +
                   "    }\n" +
                   "} // namespace\n";
        }

        private string GenerateSetup(string indent)
        {
            List<string> setUp = new List<string> {
                    "[TestFixtureSetUp]\n", 
                    "public void SetUp() {\n",
                    "    // Arrange \n",
                    "    var dbProvider = new DbProvider(\"" + _connectionString + "\");\n",
                    "    _dbSpecification = dbProvider.LoadSchemaSpecification();\n",                    
                    "}\n",
                };

            string result = "";
            setUp.ForEach(x => result += indent + x);
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
                                  "\n",
                                  "    // Act \n",
                                  "    manual.AssertIsSatisfiedBy(_dbSpecification);\n",                                   
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
