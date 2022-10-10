using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Validators.AddressValidators
{
    public class InsertAddressValidator : AbstractValidator<InsertAddressRequest>
    {
        public InsertAddressValidator()
        {
            RuleFor(x => x.Guid).NotNull().NotEmpty().WithMessage("Guid cannot be null or empty!");
            RuleFor(x => x.Line1).NotEmpty().WithMessage("Address Line 1 is a required field for addresses.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is a required field for addresses.");
            RuleFor(x => x.StateId).NotEmpty().WithMessage("State is a required field for addresses.");
        }
    }
}
