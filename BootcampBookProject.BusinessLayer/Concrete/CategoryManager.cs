using BootcampBookProject.BusinessLayer.Abstract;
using BootcampBookProject.DataAccessLayer.Abstract;
using BootcampBookProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public List<Book> TGetCategoryWithBooks(int id)
		{
			return _categoryDal.GetCategoryWithBooks(id);
		}

		public void TDelete(int id)
		{
			_categoryDal.Delete(id);
		}

		public List<Category> TGetAll()
		{
			return _categoryDal.GetAll();
		}

		public Category TGetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public List<Category> TGetCategoriesByStatusTrue()
		{
			return _categoryDal.GetCategoriesByStatusTrue();
		}

		public void TInsert(Category entity)
		{
			_categoryDal.Insert(entity);
		}

		public void TUpdate(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
