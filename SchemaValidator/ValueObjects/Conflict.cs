using System;
using System.Collections.Generic;

namespace SchemaValidator.ValueObjects
{
    public class Conflict
    {
        public List<Column> MissingColumns { get; private set; }
    }
}