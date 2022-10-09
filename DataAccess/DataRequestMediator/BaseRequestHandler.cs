namespace RedRainParks.DataAccessMediator
{
    public abstract class BaseRequestHandler
    {
        protected readonly IDataHandler _dataHandler;

        protected readonly IMapper _mapper;

        public BaseRequestHandler(IDataHandler dataHandler, IMapper mapper)
        {
            _dataHandler = dataHandler;
            _mapper = mapper;
        }
    }
}
