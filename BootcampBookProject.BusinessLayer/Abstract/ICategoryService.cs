﻿using BootcampBookProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.BusinessLayer.Abstract
{
	public interface ICategoryService : IGenericService<Category>
	{
		List<Category> TGetCategoriesByStatusTrue();
		List<Book> TGetCategoryWithBooks(int id);
	}
}
