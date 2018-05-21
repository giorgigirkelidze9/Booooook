using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booooooooooooooooooook.Models
{
	public class Category
	{

		public int CategoryId { get; set; }

		public string Name { get; set; }
		public List<Book> Books { get; set; }

	}
}