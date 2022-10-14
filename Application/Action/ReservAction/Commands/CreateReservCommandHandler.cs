
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MongoDB.Driver;

namespace Application.Action.ReservAction.Commands
{
    public class CreateReservCommandHandler:IRequestHandler<CreateReservCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Reserv> _mongoReserv;

        public CreateReservCommandHandler(IApplicationDbContext context, IMapper mapper, IMongoSettings mongoSettings)
        {
            _context = context;
            _mapper = mapper;
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _mongoReserv = database.GetCollection<Reserv>("Reservs");
        }

        public async Task<Guid> Handle(CreateReservCommand request, CancellationToken cancellationToken)
        {
            var newNote = _mapper.Map<Reserv>(request.newReserv);

            await _context.Reservs.AddAsync(newNote);
            await _context.SaveChangesAsync(cancellationToken);

            await _mongoReserv.InsertOneAsync(newNote, cancellationToken);

            return newNote.Id;
        }
    }
}
