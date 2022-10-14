using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Reserv> Reservs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
