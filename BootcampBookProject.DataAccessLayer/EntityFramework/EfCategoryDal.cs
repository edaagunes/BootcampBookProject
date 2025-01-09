using BootcampBookProject.DataAccessLayer.Abstract;
using BootcampBookProject.DataAccessLayer.Context;
using BootcampBookProject.DataAccessLayer.Repositories;
using BootcampBookProject.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.DataAccessLayer.EntityFramework
{
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
	{
		public EfCategoryDal(BookContext bookContext) : base(bookContext)
		{
		}

		public List<Category> GetCategoriesByStatusTrue()
		{
			using var context= new BookContext();
			return context.Categories.Where(x=>x.Status==true).ToList();
		}

		public List<Book> GetCategoryWithBooks(int id)
		{
			using var context = new BookContext();
			var values=context.Books.Include(x=>x.Category).Where(x=>x.CategoryId==id).ToList();
			return values;
		}
	}
}
