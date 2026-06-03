using InntechBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace InntechBackend.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
