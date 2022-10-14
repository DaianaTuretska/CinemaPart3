using MediatR;

namespace Application.Action.ReservAction.Commands
{
    public class DeleteReservCommand:IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
