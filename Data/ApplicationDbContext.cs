using APIMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPIS.Data
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Genders> Genders { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genders)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenres"));

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(j => j.ToTable("MovieActors"));
        }

    }
}
