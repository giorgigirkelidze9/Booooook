using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Booooooooooooooooooook.Models;
namespace Booooooooooooooooooook.Viewsss
{
	public class ShoppingCart
	{
		public int ID { get; set; }
		public List<Cart> Books { get; set; }
		public decimal Total { get; set; }
	}
}