using Microsoft.EntityFrameworkCore;

namespace WebAppsProsjekt1.Models;

public class FlashCardDbContext : DbContext
{
    public FlashCardDbContext(DbContextOptions<FlashCardDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<FlashCard> FlashCards { get; set; }
}