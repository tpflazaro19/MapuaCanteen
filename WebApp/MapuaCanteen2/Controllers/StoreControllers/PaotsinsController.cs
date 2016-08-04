using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MapuaCanteen2.Models.Stores;

namespace MapuaCanteen2.Controllers.StoreControllers
{
    public class PaotsinsController : Controller
    {
        private MapuaCanteenDBContext db = new MapuaCanteenDBContext();

        // GET: Paotsins
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Paotsins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paotsin paotsin = db.Products.Find(id);
            if (paotsin == null)
            {
                return HttpNotFound();
            }
            return View(paotsin);
        }

        // GET: Paotsins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paotsins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Image,Item,PreparationTime,Price,Remarks,Stock")] Paotsin paotsin)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(paotsin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paotsin);
        }

        // GET: Paotsins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paotsin paotsin = db.Products.Find(id);
            if (paotsin == null)
            {
                return HttpNotFound();
            }
            return View(paotsin);
        }

        // POST: Paotsins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,Item,PreparationTime,Price,Remarks,Stock")] Paotsin paotsin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paotsin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paotsin);
        }

        // GET: Paotsins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paotsin paotsin = db.Products.Find(id);
            if (paotsin == null)
            {
                return HttpNotFound();
            }
            return View(paotsin);
        }

        // POST: Paotsins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paotsin paotsin = db.Products.Find(id);
            db.Products.Remove(paotsin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: PaotsinProducts/Store
        public ActionResult Store()
        {
            return View(db.Products.ToList());
        }

        //GET: PaotsinProducts/Order
        public string Order(string Image, string Item, decimal PreparationTime, decimal Price, string Remarks, int Quantity, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Image: " + Image + ", Item: " + Item + ", ID=" + ID + ", PT: " + PreparationTime + ", Price: " + Price + ", Remarks: " + Remarks + ", Quantity: " + Quantity);
        }
    }
}
