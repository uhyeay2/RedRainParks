namespace RedRainParks.Domain.Interfaces
{
    #region Repositories

    public interface IAddressRepository : IRepository { }

    public interface IStateLookupRepository : IRepository { }

    public interface IUsedGuidsRepository : IRepository { }

    public interface IParkLocationRepository : IRepository { }

    #endregion

    #region RepositoryBase

    public interface IRepository : IFetch, IFetchList, IExecute { }

    public interface IRepositoryWithObjectHierarchyMapSettings : IRepository, IFetchWithObjectHierarchyMapSettings, IFetchListWithObjectHierarchyMapSettings { }

    #endregion

    #region Fetch

    public interface IFetch
    {
        Task<TOutput?> FetchAsync<TInput, TOutput>(TInput input);
    }

    public interface IFetchWithObjectHierarchyMapSettings
    {
        Task<TOutput?> FetchAsync<TInput, TFirst, TSecond, TOutput>(TInput input, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id");
    }

    #endregion

    #region Fetch List

    public interface IFetchList
    {
        Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput input);
    }

    public interface IFetchListWithObjectHierarchyMapSettings
    {
        Task<TOutput> FetchListAsync<TInput, TFirst, TSecond, TOutput>(TInput input, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id");
    }

    #endregion

    #region Execute

    public interface IExecute
    {
        Task<int> ExecuteAsync<TInput>(TInput input);
    }

    #endregion
}