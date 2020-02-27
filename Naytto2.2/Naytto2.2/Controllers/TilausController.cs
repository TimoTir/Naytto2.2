using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Naytto2._2.Models;

namespace Naytto2._2.Controllers
{
    public class TilausController : Controller
    {
        private TestifkpkEntities db = new TestifkpkEntities();

        // GET: Tilaus
        public ActionResult Index()
        {
            var tilaus = db.Tilaus.Include(t => t.Asiakkaat);
            return View(tilaus.ToList());
        }

        // GET: Tilaus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaus tilaus = db.Tilaus.Find(id);
            if (tilaus == null)
            {
                return HttpNotFound();
            }
            return View(tilaus);
        }

        // GET: Tilaus/Create
        public ActionResult Create()
        {
            ViewBag.asiakasId = new SelectList(db.Asiakkaat, "asiakasId", "Yhteyshenkilö");
            return View();
        }

        // POST: Tilaus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tilausId,asiakasId,TilausPvm")] Tilaus tilaus)
        {
            if (ModelState.IsValid)
            {
                db.Tilaus.Add(tilaus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.asiakasId = new SelectList(db.Asiakkaat, "asiakasId", "Yhteyshenkilö", tilaus.asiakasId);
            return View(tilaus);
        }

        // GET: Tilaus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaus tilaus = db.Tilaus.Find(id);
            if (tilaus == null)
            {
                return HttpNotFound();
            }
            ViewBag.asiakasId = new SelectList(db.Asiakkaat, "asiakasId", "Yhteyshenkilö", tilaus.asiakasId);
            return View(tilaus);
        }

        // POST: Tilaus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tilausId,asiakasId,TilausPvm")] Tilaus tilaus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tilaus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.asiakasId = new SelectList(db.Asiakkaat, "asiakasId", "Yhteyshenkilö", tilaus.asiakasId);
            return View(tilaus);
        }

        // GET: Tilaus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaus tilaus = db.Tilaus.Find(id);
            if (tilaus == null)
            {
                return HttpNotFound();
            }
            return View(tilaus);
        }

        // POST: Tilaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tilaus tilaus = db.Tilaus.Find(id);
            db.Tilaus.Remove(tilaus);
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
