using System;

namespace SchemaValidator
{
    public class SpecificationException : Exception
    {
        public SpecificationException() {}
        public SpecificationException(string message ): base( message ) {}
    }
}