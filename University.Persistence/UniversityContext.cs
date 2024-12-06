using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence.Configuration;

namespace University.Persistence
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Mark> Mark { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=University-EF;Trusted_Connection=True;ConnectRetryCount=0;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
        }
    }
}
