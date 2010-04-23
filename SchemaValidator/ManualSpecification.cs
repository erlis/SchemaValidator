using SchemaValidator.ValueObjects;

namespace SchemaValidator
{
    public class ManualSpecification : SchemaSpecification
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbSpecification"></param>
        public void AssertIsSatisfiedBy(DbSpecification dbSpecification)
        {
            CompareResult result = Compare(dbSpecification); 
            if (result.HaveValues)
            {
                throw new SpecificationException( result.ToString() );
            }
        }
    }
}