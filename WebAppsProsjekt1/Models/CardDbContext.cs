using System;
using Microsoft.EntityFrameworkCore;


namespace WebAppsProsjekt1.Models;


public class CardDbContext : DbContext
{
    public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
    {
        Database.EnsureCreated(); // crate a database
    }

        public DbSet<Cardset> Cardsets { get; set; } // get cards and other info from ViewModels
}

