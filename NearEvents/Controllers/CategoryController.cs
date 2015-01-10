using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NearEvents.Models;

namespace NearEvents.Controllers
{
    public class CategoryController : Controller
    {
        private MyAroundEntities db = new MyAroundEntities();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.tCategory.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCategory tCategory = db.tCategory.Find(id);
            if (tCategory == null)
            {
                return HttpNotFound();
            }
            return View(tCategory);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,count")] tCategory tCategory)
        {
            if (ModelState.IsValid)
            {
                db.tCategory.Add(tCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tCategory);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCategory tCategory = db.tCategory.Find(id);
            if (tCategory == null)
            {
                return HttpNotFound();
            }
            return View(tCategory);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,count")] tCategory tCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tCategory);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCategory tCategory = db.tCategory.Find(id);
            if (tCategory == null)
            {
                return HttpNotFound();
            }
            return View(tCategory);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tCategory tCategory = db.tCategory.Find(id);
            db.tCategory.Remove(tCategory);
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
    }
}
