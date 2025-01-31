﻿using BootcampBookProject.BusinessLayer.Abstract;
using BootcampBookProject.BusinessLayer.ValidationRules.BookValidator;
using BootcampBookProject.BusinessLayer.ValidationRules.CategoryValidator;
using BootcampBookProject.EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using X.PagedList.Extensions;

namespace BootcampBookProject.Controllers
{
	[Authorize]
	public class BookController : Controller
	{
		private readonly IBookService _bookService;
		private readonly ICategoryService _categoryService;

		public BookController(IBookService bookService, ICategoryService categoryService)
		{
			_bookService = bookService;
			_categoryService = categoryService;
		}

		public IActionResult BookList(string searchQuery,int page=1,int pageSize=5)
		{
			ViewBag.PageTitle = "Kitaplar";

			var books = _bookService.TGetAllBooksWithCategory();

			if (!string.IsNullOrEmpty(searchQuery))
			{
				searchQuery = searchQuery.ToLower();
				books = books.Where(b => b.Name.ToLower().Contains(searchQuery) ||
									b.Author.ToLower().Contains(searchQuery) || 
									b.Description.ToLower().Contains(searchQuery) ||
									b.Category.CategoryName.ToLower().Contains(searchQuery)
									).ToList();
			}

			var pagedBooks = books.ToPagedList(page, pageSize);

			return View(pagedBooks);
		}
		public IActionResult DeleteBook(int id)
		{
			_bookService.TDelete(id);
			return RedirectToAction("BookList");
		}

		[HttpGet]
		public IActionResult CreateBook()
		{
			ViewBag.PageTitle = "Kitap Ekle";

			var values = _categoryService.TGetCategoriesByStatusTrue();

			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryId.ToString()
											}).ToList();

			ViewBag.categories = values2;

			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> CreateBook(Book book, IFormFile file)
		{
			ModelState.Clear();

			ViewBag.PageTitle = "Kitap Ekle";

			var categoryList = _categoryService.TGetCategoriesByStatusTrue();
			ViewBag.categories = categoryList.Select(x => new SelectListItem
			{
				Text = x.CategoryName,
				Value = x.CategoryId.ToString()
			}).ToList();

			if (file != null && file.Length > 0)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(file.FileName);
				var imageName = Guid.NewGuid() + extension;
				var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);

				using (var stream = new FileStream(saveLocation, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				// Kitap modeline görselin URL'sini atıyoruz
				book.ImageUrl = "/images/" + imageName;
			}

			else
			{
				// Görsel yüklenmediyse, boş bir string atıyoruz
				book.ImageUrl = "";
			}

			CreateBookValidator validationRules = new CreateBookValidator();
			ValidationResult result = validationRules.Validate(book);

			if (result.IsValid)
			{
				book.Status = true;
				_bookService.TInsert(book);
				return RedirectToAction("BookList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(book);
		}

		[HttpGet]
		public IActionResult UpdateBook(int id)
		{
			ViewBag.PageTitle = "Kitap Güncelle";

			var book=_bookService.TGetById(id);

			var values = _categoryService.TGetCategoriesByStatusTrue();

			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryId.ToString()
											}).ToList();

			ViewBag.categories = values2;
			return View(book);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBook(Book book, IFormFile file)
		{
			ViewBag.PageTitle = "Kitap Güncelle";

			ModelState.Clear();

			var values = _categoryService.TGetCategoriesByStatusTrue();

			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryId.ToString()
											}).ToList();

			ViewBag.categories = values2;

			// Mevcut kitap verisini veritabanından alın
			var existingBook = _bookService.TGetById(book.BookId);
			if (existingBook == null)
			{
				return NotFound();
			}

			// Görsel güncelleme işlemi
			if (file != null && file.Length > 0)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(file.FileName);
				var imageName = Guid.NewGuid() + extension;
				var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);

				using (var stream = new FileStream(saveLocation, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				existingBook.ImageUrl = "/images/" + imageName;
			}

			// Diğer alanları güncelle
			existingBook.Name = book.Name;
			existingBook.Author = book.Author;
			existingBook.Description = book.Description;
			existingBook.CategoryId = book.CategoryId;

			// FluentValidation ile doğrulama
			CreateBookValidator validationRules = new CreateBookValidator();
			ValidationResult result = validationRules.Validate(existingBook);

			if (result.IsValid)
			{
				_bookService.TUpdate(existingBook);
				return RedirectToAction("BookList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(book);
		}


		public IActionResult ChangeStatusFalse(int id)
		{
			_bookService.TChangeStatusFalse(id);
			return RedirectToAction("BookList");
		}

		public IActionResult ChangeStatusTrue(int id)
		{
			_bookService.TChangeStatusTrue(id);
			return RedirectToAction("BookList");
		}
	
		
	}
}
