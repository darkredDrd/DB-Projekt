using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence.Configuration;

namespace University.Persistence
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Revenue> Students { get; set; }

        public DbSet<Cinema> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Hall> Marks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
        }
    }
}
