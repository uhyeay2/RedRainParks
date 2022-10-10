using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Validators.AddressValidators
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Guid).NotEmpty().WithMessage("Guid is required for locating Address");
            RuleFor(x => x.Line1).NotEmpty().WithMessage("Address Line 1 field is required for addresses.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Address City field is required for addresses.");
        }
    }
}
