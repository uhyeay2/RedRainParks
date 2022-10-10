using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Validators.AddressValidators
{
    public class DeleteAddressValidator : AbstractValidator<DeleteAddressRequest>
    {
        public DeleteAddressValidator()
        {
            RuleFor(x => x.Guid).NotEmpty().WithMessage("Guid is required to locate the Address to delete");
        }
    }
}
