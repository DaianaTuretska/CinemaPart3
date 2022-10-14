using Application.DTO.Request.ReservControllerRequest;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Interfaces.ValidatorServicesInterfaces
{
    public interface IReservValidatorService
    {
        public IValidator<NewReservReqModel> _validatorNewReserv { get; }
        public Task<string> GetErrorsValidationAsync(ValidationResult resultValidation);
    }
}
