﻿using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.Controllers
{
	public class BookController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
