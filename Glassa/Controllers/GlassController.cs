using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Glassa.Models;

namespace Glassa.Controllers
{
    public class GlassController : Controller
    {
        private GlassDBContext db = new GlassDBContext();

        // GET: Glass
        public ActionResult Index()
        {
            return View(db.Glassar.ToList());
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
        public ActionResult Create([Bind(Include = "ID,Name,Price,Maker,Picture,Tasted")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                db.Glassar.Add(glass);
                db.SaveChanges();
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
