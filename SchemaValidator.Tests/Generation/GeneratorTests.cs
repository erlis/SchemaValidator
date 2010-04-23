using System;
using System.IO;
using NUnit.Framework;
using SchemaValidator.Generation;

namespace SchemaValidator.Tests.Generation
{
    [TestFixture]
    public class GeneratorTests
    {

        [Test]
        [Explicit]
        public void Test_Generation()
        {
            TestGenerator generator = new TestGenerator("Data Source=mfstest;Initial Catalog=Rel5Test;User ID=momentis;Password=HGDHSWGWYIBWGQDIJSGXDHZSGSRHXA;");
            StreamWriter streamWriter = File.CreateText(@"C:\temp\tests.cs");
            streamWriter.Write( generator.GenerateTest() ); 
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
