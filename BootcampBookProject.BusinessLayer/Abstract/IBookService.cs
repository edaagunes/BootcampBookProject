using BootcampBookProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.BusinessLayer.Abstract
{
	public interface IBookService : IGenericService<Book>
	{
		List<Book> TGetAllBooksWithCategory();
		void TChangeStatusFalse(int id);
		void TChangeStatusTrue(int id);
	}
}
