using BootcampBookProject.DataAccessLayer.Context;
using BootcampBookProject.BusinessLayer.Container;
using BootcampBookProject.EntityLayer.Entities;
using BootcampBookProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BookContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.ContainerDependencies();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
