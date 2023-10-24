using System;

using Microsoft.EntityFrameworkCore;


namespace WebAppsProsjekt1.Models;


public static class DBInit
{
    public static void Seed(IApplicationBuilder app)
    {

        using var serviceScope = app.ApplicationServices.CreateScope();
        CardDbContext context = serviceScope.ServiceProvider.GetRequiredService<CardDbContext>();
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();


        if (!context.Cardsets.Any())
        {
            var card = new List<Cardset>
            {
                new Cardset
                {
                    CardSetName = "Birds",
                    Description = "Learn about the birds",
                    ImageUrl = "/images/birds.jpg"
                },
                new Cardset
                {
                    CardSetName = "fish",
                    Description = "Learn about fish",
                    ImageUrl = "/images/fish.jpg"

                },
                new Cardset
                {
                    CardSetName = "Flowers",
                    Description = "Learn about flowers",
                    ImageUrl = "/images/flowes.jpg"
                },
                new Cardset
                {
                    CardSetName = "Home",
                    Description = "Learn about home",
                    ImageUrl = "/images/home.jpg"
                },
                new Cardset
                {
                    CardSetName = "School",
                    Description = "Learn about school",
                    ImageUrl = "/images/school.jpg"
                },
                new Cardset
                {
                    CardSetName = "Winter",
                    Description = "Learn about winter",
                    ImageUrl = "/images/winter.jpg"
                },
                new Cardset
                {
                    CardSetName = "Wild Animals",
                    Description = "Learn about Wild Animals",
                    ImageUrl = "/images/wild_animals.jpg"
                },

            };
            context.AddRange(card);
            context.SaveChanges();
        }

        context.SaveChanges();


    }

}

