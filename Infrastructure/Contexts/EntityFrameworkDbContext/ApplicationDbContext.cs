using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.EntityFrameworkDbContext
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public DbSet<Reserv> Reservs { get; set; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
