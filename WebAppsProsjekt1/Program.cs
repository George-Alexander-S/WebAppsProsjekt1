using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using Microsoft.AspNetCore.Identity;
using WebAppsProsjekt1.DAL;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CardDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CardDbContextConnection' not found.");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CardDbContext>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:CardDbContextConnection"]);
});


builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<CardDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<ICardRepository, CardRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

app.UseStaticFiles();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
