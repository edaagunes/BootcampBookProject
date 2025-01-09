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

// Kimlik do�rulama ve yetkilendirme i�in servisleri ekleme
builder.Services.AddAuthentication("Cookies")
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Index";  // Login sayfas�
		options.AccessDeniedPath = "/Account/AccessDenied";  // Yetkisiz eri�im sayfas�
	});

builder.Services.AddAuthorization(options =>
{
	options.FallbackPolicy = options.DefaultPolicy; // Varsay�lan politika
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
