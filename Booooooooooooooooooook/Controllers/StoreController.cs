using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booooooooooooooooooook.Models;
namespace Booooooooooooooooooook.Controllers
{
    public class StoreController : Controller
    {
		private myDBContext db = new myDBContext();

		// GET: Store
		public ActionResult Index()
		{

			var category = db.Categories.ToList();
			return View(category);
		}
		public ActionResult Browse(string category)
		{
			var book = db.Categories.Include("Books").Single(c => c.Name == category);
			return View(book);
		}
		public ActionResult Details(int id)
		{
			var book = db.Books.Find(id);
			return View(book);
		}
		[ChildActionOnly]
		public ActionResult Category()
		{
			var cat = db.Categories.ToList();
			return PartialView(cat);

		}
	}
}