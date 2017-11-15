using Microsoft.EntityFrameworkCore;
 
// Change Namespace
namespace TheDojoLeague.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        // Example of connecting user to the DB
        // 
        // public DBSet<(Model)> (Db Table) { get; set; }
        // 
        public DbSet<User> Users { get; set; }
        public DbSet<Dojo> Dojos { get; set; }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
}