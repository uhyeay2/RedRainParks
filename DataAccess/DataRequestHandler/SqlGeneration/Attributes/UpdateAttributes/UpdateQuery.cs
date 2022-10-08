namespace DataRequestHandler.SqlGeneration.Attributes.UpdateAttributes
{
    public class UpdateQuery : SqlScriptAttribute
    {
        public UpdateQuery(string table, string where) : base(table, where)
        {
        }
    }
}
