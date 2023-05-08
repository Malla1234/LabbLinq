using LabbLinq.Models;
using Microsoft.EntityFrameworkCore;

namespace LabbLinq.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SearchViewModel> SearchViewModel { get; set; }
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<StudentClass> StudentClasses { get; set; } = default!;
        public DbSet<SchoolConnection> SchoolConnections { get; set; } = default!;

    }
}

