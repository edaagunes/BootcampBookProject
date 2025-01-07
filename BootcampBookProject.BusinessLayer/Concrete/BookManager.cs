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
	public class BookManager : IBookService
	{
		private readonly IBookDal _bookDal;

		public BookManager(IBookDal bookDal)
		{
			_bookDal = bookDal;
		}

		public void TDelete(int id)
		{
			_bookDal.Delete(id);
		}

		public List<Book> TGetAll()
		{
			return _bookDal.GetAll();
		}

		public Book TGetById(int id)
		{
			return _bookDal.GetById(id);
		}

		public void TInsert(Book entity)
		{
			_bookDal.Insert(entity);
		}

		public void TUpdate(Book entity)
		{
			_bookDal.Update(entity);
		}
	}
}
