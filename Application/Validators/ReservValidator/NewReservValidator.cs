using Application.DTO.Request.ReservControllerRequest;
using FluentValidation;

namespace Application.Validators.PostValidators
{
    public class NewReservValidator : AbstractValidator<NewReservReqModel>
    {
        public NewReservValidator()
        {
           RuleFor(x => x.reserv_date)
               .Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Create date is empty");
        }
    }
}
