using Microsoft.EntityFrameworkCore;
 
// Change Namespace
namespace CodeFirstTemplate.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        // Example of connecting user to the DB
        // 
        // public DBSet<(Model)> (Db Table) { get; set; }
        // 
        public DbSet<User> Users { get; set; }
    }
}