using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBirdRepository, BirdRepository>();
builder.Services.AddRazorPages().AddRazorPagesOptions(options => { options.Conventions.AddPageRoute("/HomePage", ""); });
builder.Services.AddDbContext<BirdFarmShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BirdFarmShop") ?? throw new InvalidOperationException("Connection string 'BirdFarmShop' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
