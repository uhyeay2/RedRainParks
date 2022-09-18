using RedRainParks.Domain.Interfaces;
using System.Web.Http.ExceptionHandling;

namespace RedRainParks.API.Middlewares
{
    public class ExceptionLoggingMiddleware : ExceptionLogger
    {
        private readonly ILoggingRepository _repository;

        public ExceptionLoggingMiddleware(ILoggingRepository loggingRepository)
        {
            _repository = loggingRepository;
        }

        public override void Log(ExceptionLoggerContext context)
        {

        }

    }
}
