using SchemaValidator.ValueObjects.Conflict;
using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator
{
    public class ManualSpecification : SchemaSpecification
    {

        public void AssertIsSatisfiedBy(DbSpecification dbSpecification)
        {
            CompareResult result = Compare(dbSpecification); 
            if (result.HaveValues)
            {
                throw new SpecificationException( "\n" + result );
            }
        }

        public Table RequireTable( string tableName )
        {
            return AddTable(tableName); 
        }

    }
}