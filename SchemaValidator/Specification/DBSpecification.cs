using System;
using System.Collections.Generic;
using SchemaValidator.ValueObjects.DBElements;
namespace SchemaValidator.Specification
{
    public class DBSpecification : SchemaSpecification
    {
        /// constructor
        public DBSpecification(List<Table> tableList)
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