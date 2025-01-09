using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.EntityLayer.Entities
{
	public class Book
	{
		public int BookId { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string? ImageUrl { get; set; }
		public bool Status { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
