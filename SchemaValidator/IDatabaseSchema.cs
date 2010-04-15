using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaValidator
{
    interface IDatabaseSchema
    {
        SchemaSpecification LoadSchemaSpecification();
    }
}
