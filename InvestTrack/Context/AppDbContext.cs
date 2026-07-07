using InvestTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestTrack.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
    }
}
