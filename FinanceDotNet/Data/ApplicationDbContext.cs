using Microsoft.EntityFrameworkCore;
using FinanceDotNet.Models;


namespace FinanceDotNet.Data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets representing tables in your SQLite database
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SavingsGoal> SavingsGoals { get; set; }
}
    }

