using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        // Example of connecting user to the DB
        // 
        // public DBSet<(Model)> (Db Table) { get; set; }
        // 
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}