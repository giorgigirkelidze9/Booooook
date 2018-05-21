using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booooooooooooooooooook.Viewsss;
using Booooooooooooooooooook.Models;
namespace Booooooooooooooooooook.Controllers
{
	[Authorize]
    public class ShoppingCartController : Controller
    {
		private myDBContext db = new myDBContext();
		// GET: ShoppingCart
		public ActionResult Index()
        {
			var c = Shopping.GetCart(this.HttpContext);


			var myView = new ShoppingCart
			{
				Books = c.GetBook(),

				Total = c.Total()
			};

			return View(myView);
		}

		public ActionResult Add(int id)
		{
			var myBook = db.Books
				.Single(item => item.BookId == id);


			var c = Shopping.GetCart(this.HttpContext);

			c.Add(myBook);


			return RedirectToAction("Index");
		}

		public ActionResult Remove(int id)
		{
			var c = Shopping.GetCart(this.HttpContext);
			c.Remove(id);
			return RedirectToAction("Index");
		}
		public ActionResult Buy()
		{
			var c = Shopping.GetCart(this.HttpContext);
			c.Empty();
			return RedirectToAction("Index");
		}
		public ActionResult Empty()
		{
			var c = Shopping.GetCart(this.HttpContext);
			c.Empty();
			return RedirectToAction("Index");
		}
	}
}