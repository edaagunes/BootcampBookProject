using BootcampBookProject.EntityLayer.Entities;
using BootcampBookProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
			if (result.Succeeded)
			{
				return RedirectToAction("BookList", "Book");
			}
			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
				return View(model);
			}
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
}
