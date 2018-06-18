using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using capstoneproject.Models;

namespace capstoneproject.Controllers
{
    public class sksController : Controller
    {
        private schoolsEntities1 db = new schoolsEntities1();

        // GET: sks
        [Authorize]
        public ActionResult Index()
        {
            return View(db.sks.ToList());
        }

        // GET: sks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sk sk = db.sks.Find(id);
            if (sk == null)
            {
                return HttpNotFound();
            }
            return View(sk);
        }

        // GET: sks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] sk sk)
        {
            if (ModelState.IsValid)
            {
                db.sks.Add(sk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sk);
        }

        // GET: sks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sk sk = db.sks.Find(id);
            if (sk == null)
            {
                return HttpNotFound();
            }
            return View(sk);
        }

        // POST: sks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] sk sk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sk);
        }

        // GET: sks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sk sk = db.sks.Find(id);
            if (sk == null)
            {
                return HttpNotFound();
            }
            return View(sk);
        }

        // POST: sks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sk sk = db.sks.Find(id);
            db.sks.Remove(sk);
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
