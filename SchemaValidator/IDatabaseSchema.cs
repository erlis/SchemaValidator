using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaValidator
{
    interface IDatabaseSchema
    {
        int LoadTables();
        int LoadTableFields(Table table);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 3e196fa9e6d4ec72ee6c79804a14ac9205308bf9
