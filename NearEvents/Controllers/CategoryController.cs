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
            ViewBag.Title = "CAtegory Page";

            return View();
        }
        public JsonResult GetAll()
        {
            using (DemoContext contextObj = new DemoContext())
            {
                var categoryList = contextObj.category.ToList();
                return Json(categoryList, JsonRequestBehavior.AllowGet);
            }
            //using (MyAroundEntities db = new MyAroundEntities())
            //{
            //    var categoryList = db.tCategory.ToList();
            //    return Json(categoryList, JsonRequestBehavior.AllowGet);
            //}
        }

        public string UpdateCategory(Category cat)
        {
            if (cat != null)
            {
                using (DemoContext contextObj = new DemoContext())
                {
                    int catId = Convert.ToInt32(cat.Id);
                    Category category = contextObj.category.Where(a => a.Id == catId).FirstOrDefault();
                    category.Name = cat.Name;

                    category.Count = Convert.ToInt32( cat.Count);
                    contextObj.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Record";
            }
        }

        public string AddCategory(Category cat)
        {
            if (cat != null)
            {
                using (DemoContext contextObj = new DemoContext())
                {
                    contextObj.category.Add(cat);
                    contextObj.SaveChanges();
                    return "Employee Added";
                }
            }
            else
            {
                return "Invalid Record";
            }
        }

        public JsonResult GetCategoryById(string id)
        {
            using (DemoContext contextObj = new DemoContext())
            {
                int Id = Convert.ToInt32(id);
                var getCategoryById = contextObj.category.Find(Id);
                return Json(getCategoryById, JsonRequestBehavior.AllowGet);
            }
        }
        public string DeleteCategory(string categoryId)
        {

            if (!String.IsNullOrEmpty(categoryId))
            {
                try
                {
                    int Id = Int32.Parse(categoryId);
                    using (DemoContext contextObj = new DemoContext())
                    {
                        var getCategory = contextObj.category.Find(Id);
                        contextObj.category.Remove(getCategory);
                        contextObj.SaveChanges();
                        return "Employee Deleted";
                    }
                }
                catch (Exception ex)
                {
                    return "Employee Not Found " + ex;
                }
            }
            else
            {
                return "Invalid Request";
            }
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
