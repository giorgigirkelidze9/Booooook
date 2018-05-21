using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booooooooooooooooooook.Models
{
	[Authorize]
	public class Shopping
	{
		string ShoppingId { get; set; }
		private myDBContext db = new myDBContext();
		public static Shopping GetCart(HttpContextBase context)
		{
			var c = new Shopping();
			c.ShoppingId = c.GetCartId(context);
			return c;
		}


		public string GetCartId(HttpContextBase context)
		{
			if (context.Session["CartId"] == null)
			{
				if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
				{
					context.Session["CartId"] =
						context.User.Identity.Name;
				}
				else
				{
					Guid tempCartId = Guid.NewGuid();
					context.Session["CartId"] = tempCartId.ToString();
				}
			}
			return context.Session["CartId"].ToString();
		}
		public static Shopping GetCart(Controller controller)
		{
			return GetCart(controller.HttpContext);
		}
		public void Empty()
		{
			var myBooks = db.Cart.Where(c => c.CartId == ShoppingId);
			if (myBooks != null)
			{
				foreach (var book in myBooks)
				{
					db.Cart.Remove(book);
				}
				db.SaveChanges();
			}
		}

		public void Add(Book book)
		{

			var myBook = db.Cart.SingleOrDefault(c => c.CartId == ShoppingId && c.BookId == book.BookId);

			if (myBook == null)
			{
				myBook = new Cart
				{
					BookId = book.BookId,
					CartId = ShoppingId,
					Num = 0,
				};
				db.Cart.Add(myBook);
			}
			myBook.Num++;
			db.SaveChanges();
		}

		public void Remove(int id)
		{

			var myBook = db.Cart.Single(c => c.CartId == ShoppingId	&& c.BookId == id);

			if (myBook != null)
			{
					db.Cart.Remove(myBook);
				db.SaveChanges();
			}
		}

	
		public List<Cart> GetBook()
		{
			return db.Cart.Where(c => c.CartId == ShoppingId).ToList();
		}
		public Decimal Total()
		{
			decimal total = 0;
			var myBook = GetBook();
			foreach (var book in myBook)
			{
				total += (book.Num * book.Book.Price);
			}
			return total;
		}

	}
}









