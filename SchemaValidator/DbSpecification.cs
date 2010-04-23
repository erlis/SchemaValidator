using System;
using System.Collections.Generic;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator
{
    public class DbSpecification : SchemaSpecification
    {
        /// constructor
        public DbSpecification(List<Table> tableList)
        {
            tableList.ForEach( AddTable);
        }

        /// methods
        public override Table AddTable(string tableName)
        {
            throw new InvalidOperationException("DB Specification cannot use AddTable");
        }
    }
}