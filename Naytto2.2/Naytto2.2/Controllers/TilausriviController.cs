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
    public class TilausriviController : Controller
    {
        private TestifkpkEntities db = new TestifkpkEntities();

        // GET: Tilausrivi
        public ActionResult Index()
        {
            var tilausrivi = db.Tilausrivi.Include(t => t.Tilaus).Include(t => t.Tuotteet);
            return View(tilausrivi.ToList());
        }

        // GET: Tilausrivi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilausrivi tilausrivi = db.Tilausrivi.Find(id);
            if (tilausrivi == null)
            {
                return HttpNotFound();
            }
            return View(tilausrivi);
        }

        // GET: Tilausrivi/Create
        public ActionResult Create()
        {
            ViewBag.tilausId = new SelectList(db.Tilaus, "tilausId", "tilausId");
            ViewBag.tuoteId = new SelectList(db.Tuotteet, "tuoteId", "Kuvaus");
            return View();
        }

        // POST: Tilausrivi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tilausId,tuoteId,Määrä")] Tilausrivi tilausrivi)
        {
            if (ModelState.IsValid)
            {
                db.Tilausrivi.Add(tilausrivi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tilausId = new SelectList(db.Tilaus, "tilausId", "tilausId", tilausrivi.tilausId);
            ViewBag.tuoteId = new SelectList(db.Tuotteet, "tuoteId", "Kuvaus", tilausrivi.tuoteId);
            return View(tilausrivi);
        }

        // GET: Tilausrivi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilausrivi tilausrivi = db.Tilausrivi.Find(id);
            if (tilausrivi == null)
            {
                return HttpNotFound();
            }
            ViewBag.tilausId = new SelectList(db.Tilaus, "tilausId", "tilausId", tilausrivi.tilausId);
            ViewBag.tuoteId = new SelectList(db.Tuotteet, "tuoteId", "Kuvaus", tilausrivi.tuoteId);
            return View(tilausrivi);
        }

        // POST: Tilausrivi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tilausId,tuoteId,Määrä")] Tilausrivi tilausrivi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tilausrivi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tilausId = new SelectList(db.Tilaus, "tilausId", "tilausId", tilausrivi.tilausId);
            ViewBag.tuoteId = new SelectList(db.Tuotteet, "tuoteId", "Kuvaus", tilausrivi.tuoteId);
            return View(tilausrivi);
        }

        // GET: Tilausrivi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilausrivi tilausrivi = db.Tilausrivi.Find(id);
            if (tilausrivi == null)
            {
                return HttpNotFound();
            }
            return View(tilausrivi);
        }

        // POST: Tilausrivi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tilausrivi tilausrivi = db.Tilausrivi.Find(id);
            db.Tilausrivi.Remove(tilausrivi);
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
