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
    public class HenkilöstöController : Controller
    {
        private TestifkpkEntities db = new TestifkpkEntities();

        // GET: Henkilöstö
        public ActionResult Index()
        {
            return View(db.Henkilöstö.ToList());
        }

        // GET: Henkilöstö/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilöstö henkilöstö = db.Henkilöstö.Find(id);
            if (henkilöstö == null)
            {
                return HttpNotFound();
            }
            return View(henkilöstö);
        }

        // GET: Henkilöstö/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Henkilöstö/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HenkilöId,Etunimi,Sukunimi,Puhelin,Email")] Henkilöstö henkilöstö)
        {
            if (ModelState.IsValid)
            {
                db.Henkilöstö.Add(henkilöstö);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(henkilöstö);
        }

        // GET: Henkilöstö/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilöstö henkilöstö = db.Henkilöstö.Find(id);
            if (henkilöstö == null)
            {
                return HttpNotFound();
            }
            return View(henkilöstö);
        }

        // POST: Henkilöstö/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HenkilöId,Etunimi,Sukunimi,Puhelin,Email")] Henkilöstö henkilöstö)
        {
            if (ModelState.IsValid)
            {
                db.Entry(henkilöstö).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(henkilöstö);
        }

        // GET: Henkilöstö/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilöstö henkilöstö = db.Henkilöstö.Find(id);
            if (henkilöstö == null)
            {
                return HttpNotFound();
            }
            return View(henkilöstö);
        }

        // POST: Henkilöstö/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Henkilöstö henkilöstö = db.Henkilöstö.Find(id);
            db.Henkilöstö.Remove(henkilöstö);
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
