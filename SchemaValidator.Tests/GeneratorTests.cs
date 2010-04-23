using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SchemaValidator.Generation;

namespace SchemaValidator.Tests
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
