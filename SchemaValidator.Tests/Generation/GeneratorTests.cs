using System;
using NUnit.Framework;
using SchemaValidator.Generation;

namespace SchemaValidator.Tests.Generation
{
    [TestFixture]
    public class GeneratorTests
    {

        [Test]
        public void Test_Generation()
        {
            TestGenerator generator = new TestGenerator("Data Source=mfstest;Initial Catalog=fosmaster;User ID=momentis;Password=HGDHSWGWYIBWGQDIJSGXDHZSGSRHXA;");
            Console.Out.Write( generator.GenerateTest() );
        }
    }
}
