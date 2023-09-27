using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
