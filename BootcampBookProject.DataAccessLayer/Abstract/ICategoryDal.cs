using BootcampBookProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.DataAccessLayer.Abstract
{
	public interface ICategoryDal : IGenericDal<Category>
	{
		List<Category> GetCategoriesByStatusTrue();
		List<Book> GetCategoryWithBooks(int id);
	}
}
