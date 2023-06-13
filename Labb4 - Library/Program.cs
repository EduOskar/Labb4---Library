using Labb4___Library.Data;
using Labb4___Library.Models;
using Labb4___Library.Repository;
using Labb4___Library.Repository.IRepository;
using Labb4___Library.Service;
using Labb4___Library.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connefctionstring for SQLDB
var connectionstring = 
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException($"The connection string is not supported.");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionstring));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//End of connectiong to SSMS
//Preload Repositorys
builder.Services.AddScoped<IRepository<BookItems>, Repository<BookItems>>();
builder.Services.AddScoped<IRepository<Customers>, Repository<Customers>>();
builder.Services.AddScoped<IRepository<BookLoans>, Repository<BookLoans>>();
builder.Services.AddScoped<IBookLoanService, BookLoansService>();


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
