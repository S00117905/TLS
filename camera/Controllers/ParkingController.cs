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
    public class ParkingController : Controller
    {
        private tls_dbEntities db = new tls_dbEntities();

        // GET: Parking
        public ActionResult Index()
        {
            var parkings = db.parkings.Include(p => p.carpark);
            return View(parkings.ToList());
        }

        // GET: Parking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking parking = db.parkings.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // GET: Parking/Create
        public ActionResult Create()
        {
            ViewBag.CarparkID = new SelectList(db.carparks, "CarparkID", "CarparkName");
            return View();
        }

        // POST: Parking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingID,CustomerID,CarparkID,TimeIn,TimeOut,Duration,Cost")] parking parking)
        {
            if (ModelState.IsValid)
            {
                db.parkings.Add(parking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarparkID = new SelectList(db.carparks, "CarparkID", "CarparkName", parking.CarparkID);
            return View(parking);
        }

        // GET: Parking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking parking = db.parkings.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarparkID = new SelectList(db.carparks, "CarparkID", "CarparkName", parking.CarparkID);
            return View(parking);
        }

        // POST: Parking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingID,CustomerID,CarparkID,TimeIn,TimeOut,Duration,Cost")] parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarparkID = new SelectList(db.carparks, "CarparkID", "CarparkName", parking.CarparkID);
            return View(parking);
        }

        // GET: Parking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parking parking = db.parkings.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: Parking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parking parking = db.parkings.Find(id);
            db.parkings.Remove(parking);
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
