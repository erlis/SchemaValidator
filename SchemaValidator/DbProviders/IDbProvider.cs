namespace SchemaValidator.DbProviders
{
    interface IDbProvider
    {
        DbSpecification LoadDbSpecification();
    }
}
