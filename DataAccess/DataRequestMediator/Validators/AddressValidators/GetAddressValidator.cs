using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Validators.AddressValidators
{
    public class GetAddressByGuidValidator : AbstractValidator<GetAddressByGuidRequest>
    {
        public GetAddressByGuidValidator()
        {
            RuleFor(x => x.Guid).NotEmpty().WithMessage("Guid is required to locate the Address to delete");
        }
    }

    public class GetAddressByIdValidator : AbstractValidator<GetAddressByIdRequest>
    {
        public GetAddressByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id field is required to search by Id");
        }
    }
}
