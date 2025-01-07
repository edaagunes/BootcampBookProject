using BootcampBookProject.DataAccessLayer.Abstract;
using BootcampBookProject.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly BookContext _bookContext;

		public GenericRepository(BookContext bookContext)
		{
			_bookContext = bookContext;
		}

		public void Delete(int id)
		{
			var values = _bookContext.Set<T>().Find(id);
			_bookContext.Set<T>().Remove(values);
			_bookContext.SaveChanges();
		}

		public List<T> GetAll()
		{
			return _bookContext.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _bookContext.Set<T>().Find(id);
		}

		public void Insert(T entity)
		{
			_bookContext.Set<T>().Add(entity);
			_bookContext.SaveChanges();
		}

		public void Update(T entity)
		{
			_bookContext.Set<T>().Update(entity);
			_bookContext.SaveChanges();
		}
	}
}
