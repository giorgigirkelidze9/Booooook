using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Booooooooooooooooooook.Models
{
	public class Cart
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SaleId { get; set; }
		public string CartId { get; set; }
		public int BookId { get; set; }
		public int Num { get; set; }
		public virtual Book Book { get; set; }
	}
}