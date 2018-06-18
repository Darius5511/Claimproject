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
    public class zcsController : Controller
    {
        private schoolsEntities db = new schoolsEntities();

        // GET: zcs
        public ActionResult Index()
        {
            var zcs = db.zcs.Include(z => z.sk);
            return View(zcs.ToList());
        }

        //[HttpPost]
        public ActionResult Search(int zipcode)
        {
            var zc = db.zcs.Find(zipcode);

            if (zc == null)
                return View("Index");
            var districtName = zc.sk.name;
          
            return View(districtName);
           
        }


        // GET: zcs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zc zc = db.zcs.Find(id);
            if (zc == null)
            {
                return HttpNotFound();
            }
            return View(zc);
        }

        // GET: zcs/Create
        public ActionResult Create()
        {
            ViewBag.skid = new SelectList(db.sks, "id", "name");
            return View();
        }

        // POST: zcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "zipcode,skid")] zc zc)
        {
            if (ModelState.IsValid)
            {
                db.zcs.Add(zc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.skid = new SelectList(db.sks, "id", "name", zc.skid);
            return View(zc);
        }

        // GET: zcs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zc zc = db.zcs.Find(id);
            if (zc == null)
            {
                return HttpNotFound();
            }
            ViewBag.skid = new SelectList(db.sks, "id", "name", zc.skid);
            return View(zc);
        }

        // POST: zcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "zipcode,skid")] zc zc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.skid = new SelectList(db.sks, "id", "name", zc.skid);
            return View(zc);
        }

        // GET: zcs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zc zc = db.zcs.Find(id);
            if (zc == null)
            {
                return HttpNotFound();
            }
            return View(zc);
        }

        // POST: zcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zc zc = db.zcs.Find(id);
            db.zcs.Remove(zc);
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
