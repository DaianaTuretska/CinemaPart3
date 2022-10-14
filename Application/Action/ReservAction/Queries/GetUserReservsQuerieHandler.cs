using Application.DTO.Response.ReservControllerResponse;
using Application.Interfaces;
using Application.Interfaces.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Application.Action.ReservAction.Queries
{
    public class GetUserReservsQuerieHandler : IRequestHandler<GetUserReservsQuerie, List<UserReservsResModel>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Reserv> _mongoPost;
        private readonly IReservService _reservService;

        public GetUserReservsQuerieHandler(IMapper mapper, IMongoSettings mongoSettings, IReservService reservService)
        {
            _mapper = mapper;
            _reservService = reservService;
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _mongoPost = database.GetCollection<Reserv>("Reservations");
        }

        public async Task<List<UserReservsResModel>> Handle(GetUserReservsQuerie request, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument("customerId", request.customer_id.ToString());
            var reservs = await _mongoPost.Find(filter).ToListAsync();
            var resReservs = _mapper.Map<List<UserReservsResModel>>(reservs);
            foreach (var reserv in resReservs)
            { 
                reserv.CheckYourReserv = _reservService.CheckReserv(request.customer_id,reserv.Id).GetAwaiter().GetResult();
            }
            return resReservs;
        }
    }
}
