using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Poiect_cafea.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Coffees");
    options.Conventions.AllowAnonymousToPage("/Coffees/Index");
    options.Conventions.AllowAnonymousToPage("/Coffees/Details");
    options.Conventions.AuthorizeFolder("/Clients", "AdminPolicy");
});
builder.Services.AddDbContext<Poiect_cafeaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Poiect_cafeaContext") ?? throw new InvalidOperationException("Connection string 'Poiect_cafeaContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Poiect_cafeaContext") ?? throw new InvalidOperationException("Connection string 'Poiect_cafeaContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
     .AddRoles<IdentityRole>()
     .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
