﻿using NUnit.Framework;
using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace SchemaValidator.Tests
{
    [TestFixture]
    public class DatabaseSchemaTests
    {
        [Test]
        public void Constructor_should_throw_exception_when_cannot_make_connection()
        {
            // Arrange
            DatabaseSchema db1 = new DatabaseSchema(@"--Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // Assert
            Assert.That(db1, Is.Not.Null);
        }

        [Test]
        public void SchemaSpecification_should_be_created_if_the_string_connection_is_OK()
        {
            // Arrange
            DatabaseSchema db1 = new DatabaseSchema(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            SchemaSpecification scdb = db1.LoadSchemaSpecification();

            // Assert
            Assert.That(scdb, Is.Not.Null);
        }

        [Test]
        public void LoadSchemaSpecification_should_update_TableCount_property()
        {
            // Arrange
            DatabaseSchema db1 = new DatabaseSchema(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\SQL Server 2000 Sample Databases\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30;User Instance=True");

            // create schema specification 
            SchemaSpecification scdb = db1.LoadSchemaSpecification();

            // Assert
            Assert.That(Is.Equals(scdb.TableCount, 13));
        }

    }
}
