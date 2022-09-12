namespace RedRainParks.Domain.Interfaces
{
    internal interface IValidatable
    {
        bool IsValid(out string failedValidationMessage);
    }
}
