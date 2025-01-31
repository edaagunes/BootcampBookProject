﻿using BootcampBookProject.DataAccessLayer.Abstract;
using BootcampBookProject.DataAccessLayer.Context;
using BootcampBookProject.DataAccessLayer.Repositories;
using BootcampBookProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.DataAccessLayer.EntityFramework
{
	public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
	{
		public EfAppUserDal(BookContext bookContext) : base(bookContext)
		{
		}
	}
}
