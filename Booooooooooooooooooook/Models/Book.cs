using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Booooooooooooooooooook.Models
{
	[Bind(Exclude ="BookId")]
	public class Book
	{
		[ScaffoldColumn(false)]
		public int BookId { get; set; }
		[DisplayName("Category")]
		public int CategoryId { get; set; }
		[StringLength(1000)]
		public string ImageLink { get; set; }
		[Required(ErrorMessage = "Entering Book Name is Required")]
		[StringLength(80)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Entering Book Author is Required")]
		public string Author { get; set; }
		public string Description { get; set; }
		[Required(ErrorMessage = "Entering Book Price is Required")]
		[Range(0.1,500,ErrorMessage ="The Price is out of Range (0.1,500)")]
		public decimal Price { get; set; }
		public virtual Category Category { get; set; }
	}
}