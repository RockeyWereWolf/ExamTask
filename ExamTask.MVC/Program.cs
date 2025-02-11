using ExamTask.Business;
using Microsoft.EntityFrameworkCore;
using ExamTask.DAL.Contexts;
using ExamTask.MVC;
using ExamTask.MVC.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ExamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"))
);
builder.Services.AddUserIdentity();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddBusinessLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Profile}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseSeedData();

app.Run();
