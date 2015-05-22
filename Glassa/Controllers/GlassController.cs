using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Glassa.Models;
using System.IO;

namespace Glassa.Controllers
{
    public class GlassController : Controller
    {
        private GlassDBContext db = new GlassDBContext();

        // GET: Glass
        public ActionResult Index()
        {
            ViewBag.all = db.Glassar.Count();
            ViewBag.tasted = db.Glassar.Count(g => g.Tasted == true);
            
            return View(db.Glassar.OrderByDescending(g => g.ID).ToList());
        }

        // GET: Glass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glass glass = db.Glassar.Find(id);
            if (glass == null)
            {
                return HttpNotFound();
            }
            return View(glass);
        }

        // GET: Glass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Maker,Picture,Tasted")] Glass glass, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var path = String.Empty;
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = glass.Name + "_" + Path.GetFileName(imageFile.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/Images"), fileName);

                    try
                    {
                        imageFile.SaveAs(filePath);
                        path = String.Format("/Content/Images/{0}", fileName);
                    }
                    catch(Exception e)
                    { }

                    glass.Picture = path;
                }

                db.Glassar.Add(glass);
                db.SaveChanges();

                ViewBag.Message = "Glassen lades till!";
                return RedirectToAction("Index");
            }

            return View(glass);
        }

        // GET: Glass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glass glass = db.Glassar.Find(id);
            if (glass == null)
            {
                return HttpNotFound();
            }
            return View(glass);
        }

        // POST: Glass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Maker,Picture,Tasted")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glass);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tasted(int id)
        {
            Glass glass = db.Glassar.Find(id);
            if (glass.Tasted == false) glass.Tasted = true;
            else glass.Tasted = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    

        // GET: Glass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glass glass = db.Glassar.Find(id);
            if (glass == null)
            {
                return HttpNotFound();
            }
            return View(glass);
        }

        // POST: Glass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Glass glass = db.Glassar.Find(id);
            db.Glassar.Remove(glass);
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
