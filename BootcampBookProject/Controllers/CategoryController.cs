using BootcampBookProject.BusinessLayer.Abstract;
using BootcampBookProject.BusinessLayer.ValidationRules.CategoryValidator;
using BootcampBookProject.EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.Controllers
{
	[Authorize]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult CategoryList()
		{
			ViewBag.PageTitle = "Kategoriler";

			var values=_categoryService.TGetAll();
			return View(values);
		}

		public IActionResult CreateCategory()
		{
			ViewBag.PageTitle = "Kategori Ekle";

			return View();
		}

		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{			
			ModelState.Clear();

			ViewBag.PageTitle = "Kategori Ekle";

			CreateCategoryValidator validationRules = new CreateCategoryValidator();
			ValidationResult result = validationRules.Validate(category);

			if (result.IsValid)
			{
				category.Status = true;
				_categoryService.TInsert(category);
				return RedirectToAction("CategoryList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(category);
		}

		public IActionResult DeleteCategory(int id)
		{ 
			_categoryService.TDelete(id);
			return RedirectToAction("CategoryList");
		}

		public IActionResult UpdateCategory(int id)
		{
			ViewBag.PageTitle = "Kategori Güncelle";

			var values=_categoryService.TGetById(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
			ViewBag.PageTitle = "Kategori Güncelle";

			ModelState.Clear();

			CreateCategoryValidator validationRules = new CreateCategoryValidator();
			ValidationResult result = validationRules.Validate(category);

			if (result.IsValid)
			{
				_categoryService.TUpdate(category);
				return RedirectToAction("CategoryList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(category);
		}
	
		public IActionResult GetCategoryWithBooks(int id)
		{
			ViewBag.PageTitle = "Kategorinin Kitapları";
			ViewBag.categoryName=_categoryService.TGetCategoryWithBooks(id).Select(x=>x.Category.CategoryName).FirstOrDefault();

			var values=_categoryService.TGetCategoryWithBooks(id);
			return View(values);
		}
	}
}
