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

    }
}