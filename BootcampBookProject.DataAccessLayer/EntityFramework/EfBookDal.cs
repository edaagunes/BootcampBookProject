﻿using BootcampBookProject.DataAccessLayer.Abstract;
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
	public class EfBookDal : GenericRepository<Book>, IBookDal
	{
		public EfBookDal(BookContext bookContext) : base(bookContext)
		{
		}

		public void ChangeStatusFalse(int id)
		{
			using var context = new BookContext();
			var value=context.Books.Where(x => x.BookId == id).FirstOrDefault();
			value.Status = false;
			context.SaveChanges();
		}

		public void ChangeStatusTrue(int id)
		{
			using var context = new BookContext();
			var value = context.Books.Where(x => x.BookId == id).FirstOrDefault();
			value.Status = true;
			context.SaveChanges();
		}

		public List<Book> GetAllBooksWithCategory()
		{
			using var context= new BookContext();
			var values=context.Books.Include(x => x.Category).ToList();
			return values;
		}
	}
}
