namespace RedRainParks.Domain.Models
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message) : base(message) { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message) { }
    }

    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string? message) : base(message) { }
    }

}
