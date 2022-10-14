using Application.DTO.Request.ReservControllerRequest;
using MediatR;

namespace Application.Action.ReservAction.Commands
{
    public class CreateReservCommand:IRequest<Guid>
    {
        public NewReservReqModel newReserv { get; set; }
    }
}
