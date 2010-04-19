using System;
using SchemaValidator.ValueObjects.DBElements;
namespace SchemaValidator.Specification
{
    public class DBSpecification : SchemaSpecification
    {
        public override Table AddTable( string tableName )
        {
            throw new InvalidOperationException("DB Specification cannot use AddTable");
        }
    }
}