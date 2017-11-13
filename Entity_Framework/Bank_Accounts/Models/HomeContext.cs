using Microsoft.EntityFrameworkCore;
 
namespace Bank_Accounts.Models
{
    public class HomeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Transaction> Transactions { get; set; }
    }
}
