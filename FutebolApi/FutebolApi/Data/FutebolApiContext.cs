using Microsoft.EntityFrameworkCore;
using FutebolApi.Models;

namespace FutebolApi.Data
{
    public class FutebolApiContext : DbContext
    {
        public FutebolApiContext (DbContextOptions<FutebolApiContext> options)
            : base(options)
        {
        }

        public DbSet<Jogador> Jogador { get; set; } = default!;
        public DbSet<Time> Time { get; set; } = default!;
    }
}
