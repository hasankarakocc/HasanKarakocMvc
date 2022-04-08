using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HkSampleProject.Areas.ManagementPanel.Helpers;
using HkSampleProject.Models.Entities;

namespace HkSampleProject.Areas.ManagementPanel.Controllers
{
    [Auth]
    public class PricingsController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/Pricings
        public ActionResult Index()
        {
            return View(db.Pricings.ToList());
        }

        // GET: ManagementPanel/Pricings/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricings pricings = db.Pricings.Find(id);
            if (pricings == null)
            {
                return HttpNotFound();
            }
            return View(pricings);
        }

        // GET: ManagementPanel/Pricings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Pricings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Create([Bind(Include = "PricingId,Name,Price,Offers,IsActive")] Pricings pricings)
        {
            if (ModelState.IsValid)
            {
                db.Pricings.Add(pricings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pricings);
        }

        // GET: ManagementPanel/Pricings/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricings pricings = db.Pricings.Find(id);
            if (pricings == null)
            {
                return HttpNotFound();
            }
            return View(pricings);
        }

        // POST: ManagementPanel/Pricings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "PricingId,Name,Price,Offers,IsActive")] Pricings pricings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pricings);
        }

        // GET: ManagementPanel/Pricings/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pricings pricings = db.Pricings.Find(id);
            if (pricings == null)
            {
                return HttpNotFound();
            }
            return View(pricings);
        }

        // POST: ManagementPanel/Pricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Pricings pricings = db.Pricings.Find(id);
            db.Pricings.Remove(pricings);
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
