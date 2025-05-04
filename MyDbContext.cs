using Microsoft.EntityFrameworkCore;

namespace TransactionDemo
{
    public class MyDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BankDB;Trusted_Connection=True;");
        }
    }
}
