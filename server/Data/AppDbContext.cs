using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pokedex.Models;

namespace Pokedex.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .Property(p => p.Types)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v ?? new List<string>()), 
                    v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>()
                );

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
