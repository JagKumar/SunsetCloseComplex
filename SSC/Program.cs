global using Microsoft.AspNetCore.Mvc;
global using SSC.Models;
global using System.Diagnostics;
global using SSC.Data;
global using Microsoft.EntityFrameworkCore;
using SSC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SscContext>(x => x.UseSqlServer("Server=ALTERAMKURMA; Database=SSC;Trusted_Connection=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<ILogin, AuthenticateLogin>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
