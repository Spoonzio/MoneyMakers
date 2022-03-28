using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyMaker.Models;

namespace MoneyMaker.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    // Add this method to ApplicationDbContext.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Currency>().HasData(SampleData.GetCurrencies());
        modelBuilder.Entity<Alert>().HasKey(a => new { a.UserId, a.FromCurrency, a.ToCurrency});
        modelBuilder.Entity<PortfolioEntry>().HasKey(p => new { p.UserId, p.EntryCurrencySym});
    }

    public DbSet<Currency>? Currencies { get; set; }
    public DbSet<Alert>? Alerts { get; set; }
    public DbSet<PortfolioEntry>? PortfolioEntry { get; set; }
}