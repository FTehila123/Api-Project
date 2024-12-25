namespace chineseAction.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;

    public class ProjectDbContext : DbContext
    {

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<Present> Presents { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPresent> CustomerPresents { get; set; }
        public DbSet<Donater> Donaters { get; set; }
        public DbSet<Winner> Winners { get; set; }
        public DbSet<Maneger> Manegers { get; set; }
    }
}
