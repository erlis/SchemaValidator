using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchemaValidator.Specification;

namespace SchemaValidator
{
    interface IDbProvider
    {
        DbSpecification LoadSchemaSpecification();
    }
}
