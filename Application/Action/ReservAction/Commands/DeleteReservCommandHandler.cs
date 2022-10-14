
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Application.Action.ReservAction.Commands
{
    public class DeleteReservCommandHandler : IRequestHandler<DeleteReservCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMongoCollection<Reserv> _mongoReserv;

        public DeleteReservCommandHandler(IApplicationDbContext context,IMongoSettings mongoSettings)
        {
            _context = context;
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _mongoReserv = database.GetCollection<Reserv>("Reservs");
        }

        public async Task<string> Handle(DeleteReservCommand request, CancellationToken cancellationToken)
        {
            Reserv reservDel = new Reserv { Id = request.Id };

            _context.Reservs.Attach(reservDel);
            _context.Reservs.Remove(reservDel);
            await _context.SaveChangesAsync(cancellationToken);

            var filter = new BsonDocument("_id", request.Id.ToString());
            _mongoReserv.DeleteOne(filter);
            return "Ok";
        }
    }
}
