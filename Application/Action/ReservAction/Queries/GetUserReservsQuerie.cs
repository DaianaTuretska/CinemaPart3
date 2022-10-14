using Application.DTO.Response.ReservControllerResponse;
using MediatR;

namespace Application.Action.ReservAction.Queries
{
    public class GetUserReservsQuerie : IRequest<List<UserReservsResModel>>
    {
        public Guid customer_id { get; set; }
    }
}
