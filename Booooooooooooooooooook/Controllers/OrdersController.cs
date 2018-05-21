using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booooooooooooooooooook.Models;

namespace Booooooooooooooooooook.Controllers
{
    public class OrdersController : Controller
    {
        private myDBContext db = new myDBContext();

        // GET: Orders
		[Authorize]
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }
		public ActionResult Index2()
		{
			return View();
		}
		// GET: Orders/Details/5
		[Authorize(Users = "gbs@gmail.com")]
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

		// GET: Orders/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public ActionResult Create([Bind(Include = "OrderId,User,First,LastName,Country,Phone,Email,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
				var items = db.Cart.ToList();
				db.Cart.RemoveRange(items);
				db.SaveChanges();
				return RedirectToAction("Index2");
            }

            return View(order);
        }

		// GET: Orders/Edit/5
		[Authorize(Users = "gbs@gmail.com")]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Users = "gbs@gmail.com")]
		public ActionResult Edit([Bind(Include = "OrderId,User,First,LastName,Country,Phone,Email,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

		// GET: Orders/Delete/5
		[Authorize(Users = "gbs@gmail.com")]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Users = "gbs@gmail.com")]
		public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
		[Authorize(Users = "gbs@gmail.com")]
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
