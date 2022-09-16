using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Data.Repositories
{
    public class UsedGuidsRepository : RepositoryBase, IUsedGuidsRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }
        public UsedGuidsRepository(IConfig config) : base(config)
        {
            _inputAndTargetSqlMappings = new();
        }
    }
}
