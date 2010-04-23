using SchemaValidator.Specification;

namespace SchemaValidator.DbProviders
{
    interface IDbProvider
    {
        DbSpecification LoadDbSpecification();
    }
}
