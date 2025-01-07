using BootcampBookProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public IActionResult BookList()
		{
			ViewBag.PageTitle = "Kitaplar";

			var values = _bookService.TGetAll();
			return View(values);
		}
	}
}
