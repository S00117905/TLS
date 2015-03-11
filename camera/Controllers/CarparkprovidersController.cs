using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using camera.DAL;

namespace camera.Controllers
{
    public class CarparkprovidersController : Controller
    {
        private tls_dbEntities db = new tls_dbEntities();

        // GET: Carparkproviders
        public ActionResult Index()
        {
            return View(db.carparkproviders.ToList());
        }

        // GET: Carparkproviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carparkprovider carparkprovider = db.carparkproviders.Find(id);
            if (carparkprovider == null)
            {
                return HttpNotFound();
            }
            return View(carparkprovider);
        }

        // GET: Carparkproviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carparkproviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarparkProviderID,ProviderName,ActiveAccountNum")] carparkprovider carparkprovider)
        {
            if (ModelState.IsValid)
            {
                db.carparkproviders.Add(carparkprovider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carparkprovider);
        }

        // GET: Carparkproviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carparkprovider carparkprovider = db.carparkproviders.Find(id);
            if (carparkprovider == null)
            {
                return HttpNotFound();
            }
            return View(carparkprovider);
        }

        // POST: Carparkproviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarparkProviderID,ProviderName,ActiveAccountNum")] carparkprovider carparkprovider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carparkprovider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carparkprovider);
        }

        // GET: Carparkproviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carparkprovider carparkprovider = db.carparkproviders.Find(id);
            if (carparkprovider == null)
            {
                return HttpNotFound();
            }
            return View(carparkprovider);
        }

        // POST: Carparkproviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carparkprovider carparkprovider = db.carparkproviders.Find(id);
            db.carparkproviders.Remove(carparkprovider);
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
