using BootcampBookProject.BusinessLayer.Abstract;
using BootcampBookProject.BusinessLayer.Concrete;
using BootcampBookProject.DataAccessLayer.Abstract;
using BootcampBookProject.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<IAppUserDal, EfAppUserDal>();
			services.AddScoped<IAppUserService, AppUserManager>();

			services.AddScoped<IBookDal, EfBookDal>();
			services.AddScoped<IBookService, BookManager>();

			services.AddScoped<ICategoryDal, EfCategoryDal>();
			services.AddScoped<ICategoryService, CategoryManager>();
		}
	}
}
