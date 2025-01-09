using BootcampBookProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.DataAccessLayer.Abstract
{
	public interface IBookDal : IGenericDal<Book>
	{
		List<Book> GetAllBooksWithCategory();
	}
}
