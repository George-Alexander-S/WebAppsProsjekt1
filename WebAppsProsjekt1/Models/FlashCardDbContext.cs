using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppsProsjekt1.Models;

public class FlashCardDbContext : IdentityDbContext
{
    public FlashCardDbContext(DbContextOptions<FlashCardDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<FlashCard> FlashCards { get; set; }
}