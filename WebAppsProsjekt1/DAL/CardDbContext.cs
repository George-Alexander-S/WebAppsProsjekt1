using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebAppsProsjekt1.Models;


public class CardDbContext : IdentityDbContext
{
    public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<Cardset> Cardsets { get; set; }
    public DbSet<FlashCard> FlashCards { get; set; }
}

