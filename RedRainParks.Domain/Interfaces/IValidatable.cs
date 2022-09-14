using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.Domain.Interfaces
{
    public interface IValidatable
    {
        bool IsValid(out string failedValidationMessage);
    }
}
