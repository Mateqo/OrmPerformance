using Microsoft.EntityFrameworkCore;
using OrmPerformance.Extension.NHibernate;
using OrmPerformance.Models.EntityFramework;
using OrmPerformance.Repositories.Dapper;
using OrmPerformance.Repositories.EntityFramework;
using OrmPerformance.Repositories.NHibernate;
using OrmPerformance.Services.Dapper;
using OrmPerformance.Services.EntityFramework;
using OrmPerformance.Services.NHibernate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(builder.Configuration["Connectionstring"]));

builder.Services.AddTransient<IEntityFrameworkRepositories, EntityFrameworkRepositories>();
builder.Services.AddTransient<IEntityFrameworkService, EntityFrameworkService>();

builder.Services.AddTransient<IDapperRepositories, DapperRepositories>();
builder.Services.AddTransient<IDapperService, DapperService>();

builder.Services.AddNHibernate(builder.Configuration["Connectionstring"]);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

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
