using System;

namespace SchemaValidator.Specification
{
    public class SpecificationException : Exception
    {
        public SpecificationException() {}
        public SpecificationException(string message ): base( message ) {}
    }
}