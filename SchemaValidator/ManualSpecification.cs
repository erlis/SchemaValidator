using SchemaValidator.ValueObjects;
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
                throw new SpecificationException( result.ToString() );
            }
        }

        public Table RequireTable( string tableName )
        {
            return AddTable(tableName); 
        }

    }
}