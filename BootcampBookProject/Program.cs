using BootcampBookProject.DataAccessLayer.Context;
using BootcampBookProject.BusinessLayer.Container;
using FluentValidation.AspNetCore;
using BootcampBookProject.EntityLayer.Entities;
using BootcampBookProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookContext>();

builder.Services.AddControllersWithViews().AddFluentValidation();


builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BookContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.ContainerDependencies();

// Kimlik doðrulama ve yetkilendirme için servisleri ekleme
builder.Services.ConfigureApplicationCookie(opts =>
{
	opts.LoginPath = "/Login/Index";
});

builder.Services.AddHttpClient();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy; // Varsayýlan politika
});

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
