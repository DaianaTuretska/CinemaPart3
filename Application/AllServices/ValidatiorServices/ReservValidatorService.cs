using Application.DTO.Request.ReservControllerRequest;
using Application.Interfaces.ValidatorServicesInterfaces;
using FluentValidation;

namespace Application.AllServices.ValidatorServices
{
    public class ReservValidatorService : GetValidationErrorsService, IReservValidatorService
    {
        public IValidator<NewReservReqModel> _validatorNewReserv{ get; }

        public ReservValidatorService(IValidator<NewReservReqModel> validatorNewPost)
        {
            _validatorNewReserv = validatorNewPost;
        }

    }
}
