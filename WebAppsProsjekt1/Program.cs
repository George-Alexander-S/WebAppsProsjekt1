using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CardDbContext>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:CardDbContextConnection"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

app.UseStaticFiles();


app.MapDefaultControllerRoute();

app.Run();
