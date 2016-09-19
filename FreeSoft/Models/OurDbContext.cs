using System.Data.Entity;

namespace FreeSoft.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}