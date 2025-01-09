using BootcampBookProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace BootcampBookProject.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public IActionResult BookList(int page=1,int pageSize=5)
		{
			ViewBag.PageTitle = "Kitaplar";

			var values = _bookService.TGetAllBooksWithCategory();
			var pagedBooks = values.ToPagedList(page, pageSize);

			return View(pagedBooks);
		}
	}
}
