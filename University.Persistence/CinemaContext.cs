using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence.Configuration;

namespace Cinema.Persistence
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Revenue> Revenues { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new RevenueConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new ScreeningConfiguration());

        }
    }
}
