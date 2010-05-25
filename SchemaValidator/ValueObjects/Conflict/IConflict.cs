using SchemaValidator.ValueObjects.DBElements;

namespace SchemaValidator.ValueObjects.Conflict
{
    public interface IConflict
    {
        IDBElement First { get; }
        IDBElement Second { get; }
        CompareResult Detail { get; }

        string ToStringIndent(string indent);
    }
}