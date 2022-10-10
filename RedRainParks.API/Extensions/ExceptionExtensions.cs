using FluentValidation;
using RedRainParks.Domain.Models;

namespace RedRainParks.API.Extensions
{
    public static class ExceptionExtensions
    {
        public static int GetStatusCode(this Exception e) => e switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            AlreadyExistsException => StatusCodes.Status409Conflict,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        public static BaseResponse<object> ParseResponse(this Exception e) => new(e.GetStatusCode(), success: false, e.GetType().Name, e.ParseContent());

        public static object ParseContent(this Exception e) => e is ValidationException validationException ?
            validationException.Errors.Select(x => $"{x.PropertyName} Failed Validation! Reason: {x.ErrorMessage}").Distinct() : e;
    }
}
